using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing spaces.
/// </summary>
public sealed class SpacesResponse
{
    /// <summary>
    /// The list of spaces in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<Space>? Spaces { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
