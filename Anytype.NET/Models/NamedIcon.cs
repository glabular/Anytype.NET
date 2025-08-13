using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

// TODO: Fix: NamedIcon currently doesn't work when creating an object.
// The API returns BadRequest even if the values provided from the official docs used.

/// <summary>
/// An icon represented by a named symbol and color.
/// </summary>
/// <remarks> 
/// Warning: Using NamedIcon may not work as expected yet. Only EmojiIcon and FileIcon are fully supported at this time.
/// </remarks>
public sealed class NamedIcon : Icon
{
    public NamedIcon(string name, string color)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Format = "icon";
    }

    /// <summary>
    /// The name of the icon.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The color of the icon.
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; set; }
}