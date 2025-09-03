using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class TypeProperty
{
#pragma warning disable CS8618

    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; } // TODO: Create enum for all possible values.

    /// <summary>
    /// The id of the property.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The key of the property.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }

#pragma warning restore CS8618
}
