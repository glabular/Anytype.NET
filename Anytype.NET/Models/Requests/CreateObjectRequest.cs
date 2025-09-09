using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// A request to create a new object.
/// </summary>
public sealed class CreateObjectRequest
{
#pragma warning disable CS8618

    /// <summary>
    /// The name of the new object.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

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
    public string Body { get; set; }

    /// <summary>
    /// The key of the object type to be created.
    /// </summary>
    [JsonPropertyName("type_key")]
    public required string TypeKey { get; set; }

    /// <summary>
    /// A list of properties that define object attributes and connections.
    /// </summary>
    [JsonPropertyName("properties")]
    public object[] Properties { get; set; }

    /// <summary>
    /// The id of the template to use.
    /// </summary>
    [JsonPropertyName("template_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string TemplateId { get; set; }

#pragma warning restore CS8618
}
