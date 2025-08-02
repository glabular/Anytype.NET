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
}
