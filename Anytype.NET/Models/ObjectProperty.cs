using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a property associated with an object in Anytype.
/// </summary>
public sealed class ObjectProperty
{
#pragma warning disable CS8618

    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; }

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

    /// <summary>
    /// The text value of the property.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// The number value of the property.
    /// </summary>
    [JsonPropertyName("number")]
    public double Number { get; set; }

    /// <summary>
    /// The selected tag value of the property.
    /// </summary>
    [JsonPropertyName("select")]
    public SelectValue Select { get; set; }

    /// <summary>
    /// The selected tag values of the property.
    /// </summary>
    [JsonPropertyName("multi_select")]
    public List<SelectValue> MultiSelect { get; set; }

    /// <summary>
    /// The date value of the property.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// The file values of the property.
    /// </summary>
    [JsonPropertyName("files")]
    public List<string> Files { get; set; }

    /// <summary>
    /// The checkbox value of the property.
    /// </summary>
    [JsonPropertyName("checkbox")]
    public bool Checkbox { get; set; }

    /// <summary>
    /// The URL value of the property.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// The email value of the property.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The phone value of the property.
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// The object values of the property.
    /// </summary>
    [JsonPropertyName("objects")]
    public List<string> Objects { get; set; }

#pragma warning restore CS8618
}