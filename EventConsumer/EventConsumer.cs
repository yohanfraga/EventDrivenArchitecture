using Confluent.Kafka;
using EventConsumer.Enums;
using EventConsumer.Events;
using Newtonsoft.Json;

namespace EventConsumer;

public class EventConsumer
{
    private const string HostName = "kafka:29092";
    private const string Topic = "orderTopic";
    private const string GroupId = "groupId";
    private IConsumer<Ignore, string> _consumer;
    
    public void CreateConnection()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = HostName,
            GroupId = GroupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        
        _consumer.Subscribe(Topic);
    }

    public void GetEvent()
    {
        var cts = new CancellationTokenSource();
        
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true; // Prevent the process from terminating.
            cts.Cancel();    // Cancel the consumer loop.
        };

        while (true)
        {
            try
            {
                var consumeResult = _consumer.Consume(cts.Token);
                
                HandledEvent(consumeResult);
            }
            catch (ConsumeException e)
            {
                Console.WriteLine($"Error occurred: {e.Error.Reason}");
            }
        }
    }

    private static void HandledEvent(ConsumeResult<Ignore, string> result)
    {
        var @event = JsonConvert.DeserializeObject<Event>(result.Message.Value);
        
        Console.WriteLine($"Consumed event: {@event?.Metadata.EventId} at {result.TopicPartitionOffset}");

        if (@event?.Metadata.Type == EEventType.Order)
        {
            //do some order processing
            
            Console.WriteLine($"Order processed: {@event.Data}");
        }
    }
}