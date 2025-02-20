using EventMessageSender;
using EventMessageSender.Events;

var eventPublisher = new EventProducer();

const string topic = "messageTopic";

eventPublisher.CreateConnection();

Console.WriteLine("Connection Created, sending the first message");

var console = "";

var i = 1;

while (console != "1")
{
    var messageEvent = new MessageSent
    {
        EventId = i,
        EventDate = DateTime.Now,
        Message = "Hello Event-Driven World!",
        SenderName = "Yohan Fraga"
    };

    await eventPublisher.PublishEventAsync(messageEvent, topic);

    i++;
    
    Console.WriteLine("press [enter] to send another message and write [1] to exit");
    console = Console.ReadLine();
}