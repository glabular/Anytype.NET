using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class SortItem
{
    /// <summary>
    /// The id of the sort.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The property key used for sorting.
    /// </summary>
    [JsonPropertyName("property_key")]
    public string PropertyKey { get; set; }

    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    /// The sort direction.
    /// </summary>
    [JsonPropertyName("sort_type")]
    public string SortType { get; set; }
}
