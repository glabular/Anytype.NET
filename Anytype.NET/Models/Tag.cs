using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class Tag
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }

    [JsonPropertyName("object")]
    public string Object { get; set; }
}
