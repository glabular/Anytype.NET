using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// A request payload for updating a tag.
/// </summary>
public sealed class UpdateTagRequest
{
#pragma warning disable CS8618
    /// <summary>
    /// The name of the tag.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The color of the tag.
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; }

#pragma warning restore CS8618
}
