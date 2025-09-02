using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing members.
/// </summary>
public sealed class ListMembersResponse
{
    /// <summary>
    /// The list of items in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<Member>? Members { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
