using Confluent.Kafka;
using EventMessageSender.Events;
using Newtonsoft.Json;

namespace EventMessageSender;

public class EventProducer
{
    private IProducer<Null, string> _producer;
    
    public void CreateConnection()
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        _producer = new ProducerBuilder<Null, string>(config).Build();
        
    }

    public async Task PublishEventAsync<T>(T @event, string topic) where T : BaseEvent
    {
        var jsonString = JsonConvert.SerializeObject(@event);

        try
        {
            var deliveryResult = await _producer.ProduceAsync(topic, new Message<Null, string> { Value = jsonString });
            Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Delivery failed: {e.Error.Reason}");
        }
        
        _producer.Flush(TimeSpan.FromSeconds(10));
    }
}