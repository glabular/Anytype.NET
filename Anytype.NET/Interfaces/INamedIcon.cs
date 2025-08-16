namespace Anytype.NET.Interfaces;

/// <summary>
/// Represents an icon that has a name and an optional color.
/// </summary>
public interface INamedIcon : IIcon
{
    string Name { get; set; }

    string Color { get; set; }
}
