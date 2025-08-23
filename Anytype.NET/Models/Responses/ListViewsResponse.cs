using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class ListViewsResponse
{
    /// <summary>
    /// The list of items in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<ViewItem>? Data { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
