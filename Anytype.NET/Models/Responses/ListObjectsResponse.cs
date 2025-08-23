using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class ListObjectsResponse
{
    /// <summary>
    /// A list of <see cref="AnyObject"/> objects returned in the response.
    /// </summary>
    [JsonPropertyName("data")]
    public List<AnyObject>? Objects { get; set; }

    /// <summary>
    /// Pagination metadata associated with the response, such as total items, offset, and limit.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
