using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class SelectValue
{
    /// <summary>
    /// The color of the icon.
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; }

    /// <summary>
    /// The id of the tag.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The key of the tag.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The name of the tag.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }
}