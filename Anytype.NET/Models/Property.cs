using Anytype.NET.Models.Enums;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a property associated with an object in Anytype.
/// </summary>
public sealed class Property
{
    /// <summary>
    /// The key identifying the property.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The unique ID of the property.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Id { get; set; }

    /// <summary>
    /// The value of a text property.
    /// </summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Text { get; set; }

    /// <summary>
    /// The value of a checkbox property.
    /// </summary>
    [JsonPropertyName("checkbox")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Checkbox { get; set; }

    /// <summary>
    /// TODO: Document purpose of this property..
    /// </summary>
    [JsonPropertyName("object")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Object { get; set; }

    /// <summary>
    /// The display name of the property.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Name { get; set; }

    /// <summary>
    /// TODO: Document purpose of this property.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Format { get; set; }

    /// <summary>
    /// The value of a date property.
    /// </summary>
    [JsonPropertyName("date")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? Date { get; set; }

    /// <summary>
    /// A list of object IDs if the property supports multiple object references.
    /// </summary>
    [JsonPropertyName("objects")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Objects { get; set; }
}
