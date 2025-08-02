using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public class SpacesPagination
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}
