using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public sealed class FilterItem
{
#pragma warning disable CS8618

    /// <summary>
    /// The id of the filter.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The property key used for filtering.
    /// </summary>
    [JsonPropertyName("property_key")]
    public string PropertyKey { get; set; }

    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; }

    /// <summary>
    /// The filter condition.
    /// </summary>
    [JsonPropertyName("condition")]
    public string Condition { get; set; } // TODO: Make enum

    /// <summary>
    /// The value used for filtering.
    /// </summary>
    [JsonPropertyName("value")]
    public object Value { get; set; }

#pragma warning restore CS8618
}
