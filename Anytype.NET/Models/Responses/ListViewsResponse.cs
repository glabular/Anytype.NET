using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing views.
/// </summary>
public sealed class ListViewsResponse
{
    /// <summary>
    /// The list of views in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<ViewItem>? Views { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
