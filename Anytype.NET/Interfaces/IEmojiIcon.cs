namespace Anytype.NET.Interfaces;

/// <summary>
/// Represents an emoji-based icon.
/// </summary>
public interface IEmojiIcon : IIcon
{
    /// <summary>
    /// The emoji of the icon.
    /// </summary>
    string Emoji { get; set; }
}
