using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public class AnyMember
{
    [JsonPropertyName("global_name")]
    public string GlobalName { get; set; }

    [JsonPropertyName("icon")]
    public Icon? Icon { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("identity")]
    public string Identity { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}
