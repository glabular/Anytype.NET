using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Base type for all icons.
/// </summary>
public abstract class Icon
{
    /// <summary>
    /// The format of the icon.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; }
}
