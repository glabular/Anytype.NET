namespace Anytype.NET.Models;

public sealed class ViewItem
{
    /// <summary>
    /// The id of the view.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The name of the view.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The layout of the view.
    /// </summary>
    public string Layout { get; set; }

    /// <summary>
    /// The list of filters.
    /// </summary>
    public List<FilterItem> Filters { get; set; }

    /// <summary>
    /// The list of sorts.
    /// </summary>
    public List<SortItem> Sorts { get; set; }
}
