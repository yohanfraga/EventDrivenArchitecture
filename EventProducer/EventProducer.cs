using Confluent.Kafka;
using EventProducer.Events;
using Newtonsoft.Json;

namespace EventProducer;

public class EventProducer
{
    private const string HostName = "kafka:29092";
    private IProducer<Null, string> _producer;
    
    public void CreateConnection()
    {
        var config = new ProducerConfig { BootstrapServers = HostName };
        
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task PublishEventAsync<T>(T @event, string topic) where T : Event
    {
        var jsonString = JsonConvert.SerializeObject(@event, Formatting.Indented);

        try
        {
            var deliveryResult = await _producer.ProduceAsync(topic, new Message<Null, string> { Value = jsonString });
            Console.WriteLine($"Delivered '{jsonString}' to '{deliveryResult.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Delivery failed: {e.Error.Reason}");
        }
        
        _producer.Flush(TimeSpan.FromSeconds(10));
    }
}