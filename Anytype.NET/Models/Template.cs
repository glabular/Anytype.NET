using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class Template
{
    /// <summary>
    /// Whether the object is archived.
    /// </summary>
    [JsonPropertyName("archived")]
    public bool Archived { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    [JsonPropertyName("icon")]
    public IIcon? Icon { get; set; }

    /// <summary>
    /// The id of the object.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The layout of the object.
    /// </summary>
    [JsonPropertyName("layout")]
    public string Layout { get; set; }

    /// <summary>
    /// The markdown body of the object.
    /// </summary>
    [JsonPropertyName("markdown")]
    public string Markdown { get; set; }

    /// <summary>
    /// The name of the object.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }

    /// <summary>
    /// The properties of the object.
    /// </summary>
    [JsonPropertyName("properties")]
    public List<ObjectProperty> Properties { get; set; }

    /// <summary>
    /// The snippet of the object.
    /// </summary>
    /// <remarks>Especially important for notes as they don't have a name.</remarks>
    [JsonPropertyName("snippet")]
    public string Snippet { get; set; }

    /// <summary>
    /// The id of the space the object is in.
    /// </summary>
    [JsonPropertyName("space_id")]
    public string SpaceId { get; set; }

    /// <summary>
    /// The type of the object, or null if the type has been deleted.
    /// </summary>
    [JsonPropertyName("type")]
    public ObjectType? Type { get; set; }
}
