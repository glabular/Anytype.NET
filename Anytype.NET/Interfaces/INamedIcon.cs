namespace Anytype.NET.Interfaces;

/// <summary>
/// Represents an icon that has a name and an optional color.
/// </summary>
public interface INamedIcon : IIcon
{
    /// <summary>
    /// The name of the icon.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// The color of the icon.
    /// </summary>
    string Color { get; set; }
}
