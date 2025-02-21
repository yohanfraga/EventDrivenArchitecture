using EventConsumer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EventConsumer.Events;

public class Metadata
{
    [JsonProperty("event_id")]
    public Guid EventId { get; init; }
    [JsonProperty("event_type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EEventType Type { get; init; }
    [JsonProperty("event_subtype")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EEventSubType SubType { get; init; }
    [JsonProperty("event_date")]
    public DateTime EventDate { get; init; }
}