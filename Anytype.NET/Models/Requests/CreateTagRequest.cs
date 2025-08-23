using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

public sealed class CreateTagRequest
{
    /// <summary>
    /// The name of the tag.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The color of the tag.
    /// </summary>
    [JsonPropertyName("color")]
    public required string Color { get; set; }
}
