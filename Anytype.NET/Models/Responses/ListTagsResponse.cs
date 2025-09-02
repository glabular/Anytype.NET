using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing tags.
/// </summary>
public sealed class ListTagsResponse
{
    /// <summary>
    /// The list of tags in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<Tag>? Tags { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
