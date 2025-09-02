using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing types.
/// </summary>
public sealed class ListTypeResponse
{
    /// <summary>
    /// The list of types in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<AnyType>? Data { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
