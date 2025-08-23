using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class SpaceResponse
{
    [JsonPropertyName("space")]
    public Space? Space { get; set; }
}
