using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class ViewItem
{
    /// <summary>
    /// The id of the view.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name of the view.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The layout of the view.
    /// </summary>
    [JsonPropertyName("layout")]
    public string Layout { get; set; }

    /// <summary>
    /// The list of filters.
    /// </summary>
    [JsonPropertyName("filters")]
    public List<FilterItem> Filters { get; set; }

    /// <summary>
    /// The list of sorts.
    /// </summary>
    [JsonPropertyName("sorts")]
    public List<SortItem> Sorts { get; set; }
}
