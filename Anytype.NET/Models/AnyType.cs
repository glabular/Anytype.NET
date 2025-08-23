using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a type in Anytype.
/// </summary>
public sealed class AnyType
{
    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }

    /// <summary>
    /// The id of the type (which is unique across spaces).
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The key of the type (can be the same across spaces for known types).
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    [JsonPropertyName("plural_name")]
    public string PluralName { get; set; }

    /// <summary>
    /// The icon of the object, or null if the object has no icon.
    /// </summary>
    [JsonPropertyName("icon")]
    public IIcon? Icon { get; set; }

    /// <summary>
    /// Whether the type is archived.
    /// </summary>
    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    /// <summary>
    /// The layout of the object.
    /// </summary>
    [JsonPropertyName("layout")]
    public string Layout { get; set; }

    /// <summary>
    /// The properties linked to the type.
    /// </summary>
    [JsonPropertyName("properties")]
    public List<TypeProperty> Properties { get; set; }
}
