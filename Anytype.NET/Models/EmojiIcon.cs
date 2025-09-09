using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// An icon represented by a Unicode emoji.
/// </summary>
public sealed class EmojiIcon : IEmojiIcon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmojiIcon"/> class.
    /// </summary>
    public EmojiIcon(string emoji)
    {
        Emoji = emoji;
        Format = "emoji";
    }

    /// <summary>
    /// The emoji to be displayed as icon.
    /// </summary>
    [JsonPropertyName("emoji")]
    public string Emoji { get; set; }

    /// <summary>
    /// The format of the icon.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get; set; }
}
