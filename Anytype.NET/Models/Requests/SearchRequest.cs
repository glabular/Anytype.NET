using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// The search parameters used to filter and sort the results.
/// </summary>
public sealed class SearchRequest
{
#pragma warning disable CS8618
    /// <summary>
    /// The text to search within object names and content; use types field for type filtering.
    /// </summary>
    [JsonPropertyName("query")]
    public string Query { get; set; }

    /// <summary>
    /// The types of objects to include in results (e.g., "page", "task", "bookmark").
    /// </summary>
    /// <remarks>See ListTypes endpoint for valid values.</remarks>
    [JsonPropertyName("types")]
    public string[] Types { get; set; }

    /// <summary>
    /// The sorting options for the search results.
    /// </summary>
    [JsonPropertyName("sort")]
    public SortOptions Sort { get; set; }

#pragma warning restore CS8618
}
