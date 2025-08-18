using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class FilterItem
{
    /// <summary>
    /// The id of the filter.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The property key used for filtering.
    /// </summary>
    [JsonPropertyName("property_key")]
    public string PropertyKey { get; set; }

    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    public string Format { get; set; }

    /// <summary>
    /// The filter condition.
    /// </summary>
    public string Condition { get; set; } // TODO: Make enum

    /// <summary>
    /// The value used for filtering.
    /// </summary>
    public object Value { get; set; }
}
