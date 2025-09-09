using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a type of an object in Anytype.
/// </summary>
public sealed class ObjectType
{
#pragma warning disable CS8618

    /// <summary>
    /// Whether the type is archived.
    /// </summary>
    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    [JsonPropertyName("icon")]
    public IIcon? Icon { get; set; }

    /// <summary>
    /// The id of the type.
    /// </summary>
    /// <remarks>Is unique across spaces.</remarks>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The key of the type.
    /// </summary>
    /// <remarks>Can be the same across spaces for known types.</remarks>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The layout of the object.
    /// </summary>
    [JsonPropertyName("layout")]
    public string Layout { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    [JsonPropertyName("plural_name")]
    public string PluralName { get; set; }

    /// <summary>
    /// The properties linked to the type.
    /// </summary>
    [JsonPropertyName("properties")]
    public List<ObjectProperty> Properties { get; set; }

#pragma warning restore CS8618
}