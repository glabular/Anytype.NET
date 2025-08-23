using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class TagResponse
{
    [JsonPropertyName("tag")]
    public Tag? Tag { get; set; }
}
