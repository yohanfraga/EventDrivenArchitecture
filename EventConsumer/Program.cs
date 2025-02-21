var eventSubscriber = new EventConsumer.EventConsumer();

eventSubscriber.CreateConnection();

eventSubscriber.GetEvent();

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();