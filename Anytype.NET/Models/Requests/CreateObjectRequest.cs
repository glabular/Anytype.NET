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
    public string Name { get; set; } = null!;

    /// <summary>
    /// Icon for the object.
    /// </summary>
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Icon? Icon { get; set; }

    /// <summary>
    /// The body content of the object.
    /// </summary>
    [JsonPropertyName("body")]    
    public string Body { get; set; } = null!;

    /// <summary>
    /// The key of the object type to be created.
    /// </summary>
    [JsonPropertyName("type_key")]
    public string TypeKey { get; set; } = null!;

    /// <summary>
    /// A list of properties that define object attributes and connections.
    /// </summary>
    [JsonPropertyName("properties")]
    public List<Property> Properties { get; set; } = [];
}
