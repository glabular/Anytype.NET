using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// An icon represented by a Unicode emoji.
/// </summary>
public sealed class EmojiIcon : Icon
{
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
}
