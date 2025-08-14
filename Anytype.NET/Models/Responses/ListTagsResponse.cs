using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response returned from the Anytype API when requesting a list of tags.
/// </summary>
public sealed class ListTagsResponse
{
    /// <summary>
    /// The list of tag items in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<AnyTag> Tags { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    public PaginationMetadata Pagination { get; set; }
}
