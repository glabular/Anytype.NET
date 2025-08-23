using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class SearchResponse
{
    [JsonPropertyName("data")]
    public List<SearchItem>? Data { get; set; }

    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
