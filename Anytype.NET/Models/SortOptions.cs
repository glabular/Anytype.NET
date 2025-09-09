using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// The sorting options for the search results.
/// </summary>
public sealed class SortOptions
{
    /// <summary>
    /// The direction to sort the search results by.
    /// </summary>
    [JsonPropertyName("direction")]
    public string Direction { get; set; } = "desc";

    /// <summary>
    /// The key of the property to sort the search results by.
    /// </summary>
    [JsonPropertyName("property_key")]
    public string PropertyKey { get; set; } = "last_modified_date";
}
