using Anytype.NET.Models.Enums;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a property associated with an object in Anytype.
/// </summary>
public sealed class Property
{
#pragma warning disable CS8618

    /// <summary>
    /// The key identifying the property.
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The ID of the property.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The value of a text property.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// The value of a checkbox property.
    /// </summary>
    [JsonPropertyName("checkbox")]
    public bool Checkbox { get; set; }

    /// <summary>
    /// TODO: Document purpose of this property..
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }

    /// <summary>
    /// The display name of the property.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// TODO: Document purpose of this property.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; }

    /// <summary>
    /// The value of a date property.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// A list of object IDs if the property supports multiple object references.
    /// </summary>
    [JsonPropertyName("objects")]
    public List<string> Objects { get; set; }

    /// <summary>
    /// The phone value of the property.
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// The email value of the property.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

#pragma warning restore CS8618
}
