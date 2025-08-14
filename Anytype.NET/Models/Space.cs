using Anytype.NET.Converters;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a Space in Anytype.
/// </summary>
public sealed class Space
{
    /// <summary>
    /// The data model of the object.
    /// </summary>
    [JsonPropertyName("object")]
    public string? ObjectType { get; set; }

    /// <summary>
    /// The unique identifier of the space.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the space.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The icon associated with the space. May be null if no icon is set.
    /// </summary>
    [JsonPropertyName("icon")]
    [JsonConverter(typeof(IconConverter))]
    public Icon? Icon { get; set; }

    /// <summary>
    /// The description of the space.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The gateway URL used to serve files and media.
    /// </summary>
    [JsonPropertyName("gateway_url")]
    public string? GatewayUrl { get; set; }

    /// <summary>
    /// The network id of the space.
    /// </summary>
    [JsonPropertyName("network_id")]
    public string? NetworkId { get; set; }
}
