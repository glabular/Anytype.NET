using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing objects.
/// </summary>
public sealed class ListObjectsResponse
{
    /// <summary>
    /// The list of objects in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<AnyObject>? Objects { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
