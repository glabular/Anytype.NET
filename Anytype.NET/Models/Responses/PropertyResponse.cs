using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class PropertyResponse
{
    [JsonPropertyName("property")]
    public TypeProperty? Property { get; set; }
}
