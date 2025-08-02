using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response returned from the Anytype API when requesting a list of spaces.
/// </summary>
public class SpacesResponse
{
    /// <summary>
    /// A list of <see cref="Space"/> objects returned in the response.
    /// </summary>
    [JsonPropertyName("data")]
    public List<Space>? Spaces { get; set; }

    /// <summary>
    /// Pagination metadata associated with the response, such as total items, offset, and limit.
    /// </summary>
    [JsonPropertyName("pagination")]
    public SpacesPagination? Pagination { get; set; }
}
