using EventProducer.Enums;
using EventProducer.Events;

var eventPublisher = new EventProducer.EventProducer();

const string topic = "orderTopic";

eventPublisher.CreateConnection();

Console.WriteLine("Connection Created, sending the first order");

for (var i = 1; i < 11 ; i++)
{
    var orderPlaced = new Event()
    {
        Metadata = new Metadata()
        {
            EventId = Guid.NewGuid(),
            Type = EEventType.Order,
            SubType = EEventSubType.Placed,
            EventDate = DateTime.Now,
        },
        Data = new
        {
            OrderId = i,
            Price = 170.00,
            Sector = "Tech"
        }
    };

    await eventPublisher.PublishEventAsync(orderPlaced, topic);
}

Console.WriteLine("All events sent");