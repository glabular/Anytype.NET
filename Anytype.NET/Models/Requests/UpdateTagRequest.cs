using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

public sealed class UpdateTagRequest
{
    /// <summary>
    /// The name of the tag.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The color of the tag.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }
}
