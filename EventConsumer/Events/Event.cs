using Newtonsoft.Json;

namespace EventConsumer.Events;

public class Event
{
    [JsonProperty("meta_data")]
    public required Metadata Metadata { get; init; }
    [JsonProperty("data")]
    public required object Data { get; init; }
}