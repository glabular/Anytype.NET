using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents a request to create a new object in Anytype.
/// </summary>
public sealed class CreateObjectRequest
{
    /// <summary>
    /// The name of the new object.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Icon for the object.
    /// </summary>
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IIcon? Icon { get; set; }

    /// <summary>
    /// The body content of the object.
    /// </summary>
    [JsonPropertyName("body")]    
    public string? Body { get; set; }

    /// <summary>
    /// The key of the object type to be created.
    /// </summary>
    [JsonPropertyName("type_key")]
    public required string TypeKey { get; set; }

    /// <summary>
    /// A list of properties that define object attributes and connections.
    /// </summary>
    [JsonPropertyName("properties")]
    public object[]? Properties { get; set; }

    /// <summary>
    /// The id of the template to use.
    /// </summary>
    [JsonPropertyName("template_id")]
    public string? TemplateId { get; set; }
}
