using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a member of an Anytype space.
/// </summary>
public class AnyMember
{
    /// <summary>
    /// The global name of the member in the network.
    /// </summary>
    [JsonPropertyName("global_name")]
    public string GlobalName { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    [JsonPropertyName("icon")]
    public Icon? Icon { get; set; }

    /// <summary>
    /// The profile object id of the member.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The identity of the member in the network.
    /// </summary>
    [JsonPropertyName("identity")]
    public string Identity { get; set; }

    /// <summary>
    /// The name of the member.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string Object { get; set; }

    /// <summary>
    /// The role of the member.
    /// </summary>
    [JsonPropertyName("role")]
    public string Role { get; set; }

    /// <summary>
    /// The status of the member.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}
