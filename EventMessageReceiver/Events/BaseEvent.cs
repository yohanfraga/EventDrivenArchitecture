namespace EventMessageReceiver.Events;

public class BaseEvent
{
    public long EventId { get; init; }
    public DateTime EventDate { get; init; }
}