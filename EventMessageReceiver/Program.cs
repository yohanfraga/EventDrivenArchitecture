using EventMessageReceiver;

var eventSubscriber = new EventConsumer();

eventSubscriber.CreateConnection();

eventSubscriber.GetMessageEvent();

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();