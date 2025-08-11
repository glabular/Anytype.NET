using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public class SpacesPagination
{
    /// <summary>
    /// The total number of items available for the endpoint.
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// The number of items skipped before starting to collect the result set.
    /// </summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>
    /// The maximum number of items returned in the result set.
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    /// <summary>
    /// A value indicating whether there are more items available beyond the current result set.
    /// </summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}
