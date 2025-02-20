using Confluent.Kafka;
using EventMessageReceiver.Events;
using Newtonsoft.Json;

namespace EventMessageReceiver;

public class EventConsumer
{
    private const string HostName = "localhost:9092";
    private const string Topic = "messageTopic";
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

    public void GetMessageEvent()
    {
        var cts = new CancellationTokenSource();
        
        Console.CancelKeyPress += (_, e) =>
        {
            e.Cancel = true; // Prevent the process from terminating.
            cts.Cancel();    // Cancel the consumer loop.
        };

        try
        {
            while (true)
            {
                try
                {
                    var consumeResult = _consumer.Consume(cts.Token);

                    var json = consumeResult.Message.Value;
                    
                    var message = JsonConvert.DeserializeObject<MessageSent>(json);
                        
                    Console.WriteLine($"Consumed message: {json} at {consumeResult.TopicPartitionOffset}");
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error occurred: {e.Error.Reason}");
                }
            }
        }
        catch (OperationCanceledException)
        {
            _consumer.Close();
        }
    }
}