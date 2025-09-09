using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// Defines the properties linked to the type in Anytype.
/// </summary>
public sealed class TypePropertyRequest
{
    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    [JsonPropertyName("format")]
    public required string Format { get; set; }

    /// <summary>
    /// The key of the property.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
