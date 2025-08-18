namespace Anytype.NET.Models;

public sealed class SortOptions
{
    /// <summary>
    /// The direction to sort the search results by.
    /// </summary>
    public string Direction { get; set; } = "desc";

    /// <summary>
    /// The key of the property to sort the search results by.
    /// </summary>
    public string PropertyKey { get; set; } = "last_modified_date";
}
