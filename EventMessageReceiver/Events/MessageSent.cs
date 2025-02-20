namespace EventMessageReceiver.Events;

public class MessageSent : BaseEvent
{
    public required string Message { get; init; }
    public required string SenderName { get; init; }
}