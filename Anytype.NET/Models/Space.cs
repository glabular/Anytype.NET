using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents a Space in Anytype.
/// </summary>
public class Space
{
    [JsonPropertyName("object")]
    public string? ObjectType { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("icon")]
    public Icon? Icon { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("gateway_url")]
    public string? GatewayUrl { get; set; }

    [JsonPropertyName("network_id")]
    public string? NetworkId { get; set; }
}
