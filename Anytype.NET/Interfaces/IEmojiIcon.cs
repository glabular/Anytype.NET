namespace Anytype.NET.Interfaces;

/// <summary>
/// Represents an emoji-based icon.
/// </summary>
public interface IEmojiIcon : IIcon
{
    string Emoji { get; set; }
}
