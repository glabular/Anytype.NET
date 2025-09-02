using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API containing search results.
/// </summary>
public sealed class SearchResponse
{
    /// <summary>
    /// The list of search results in the current response.
    /// </summary>
    [JsonPropertyName("data")]
    public List<SearchItem>? Results { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
