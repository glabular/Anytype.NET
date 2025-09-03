using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class SortItem
{
#pragma warning disable CS8618

    /// <summary>
    /// The id of the sort.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The property key used for sorting.
    /// </summary>
    [JsonPropertyName("property_key")]
    public string PropertyKey { get; set; }

    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; }

    /// <summary>
    /// The sort direction.
    /// </summary>
    [JsonPropertyName("sort_type")]
    public string SortType { get; set; }

#pragma warning restore CS8618
}
