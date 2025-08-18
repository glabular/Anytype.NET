namespace Anytype.NET.Models.Requests;

public sealed class SearchRequest
{
    /// <summary>
    /// The text to search within object names and content; use types field for type filtering.
    /// </summary>
    public string Query { get; set; }

    /// <summary>
    /// The types of objects to include in results (e.g., "page", "task", "bookmark").
    /// </summary>
    /// <remarks>See ListTypes endpoint for valid values.</remarks>
    public string[] Types { get; set; }

    /// <summary>
    /// The sorting options for the search results.
    /// </summary>
    public SortOptions Sort { get; set; }
}
