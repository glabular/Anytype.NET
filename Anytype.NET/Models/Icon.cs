using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public class Icon
{
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("file")]
    public string? File { get; set; }

    [JsonPropertyName("emoji")]
    public string? Emoji { get; set; }
        
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }
}
