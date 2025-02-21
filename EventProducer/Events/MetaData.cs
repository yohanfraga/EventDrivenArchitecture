using EventProducer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EventProducer.Events;

public class Metadata
{
    [JsonProperty("event_id")]
    public required Guid EventId { get; init; }
    [JsonProperty("event_type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EEventType Type { get; init; }
    [JsonProperty("event_subtype")]
    [JsonConverter(typeof(StringEnumConverter))]
    public EEventSubType SubType { get; init; }
    [JsonProperty("event_date")]
    public DateTime EventDate { get; init; }
}