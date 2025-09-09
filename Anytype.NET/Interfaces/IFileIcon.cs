namespace Anytype.NET.Interfaces;

/// <summary>
/// Represents an icon that references a file.
/// </summary>
public interface IFileIcon : IIcon
{
    /// <summary>
    /// The file of the icon.
    /// </summary>
    string File { get; set; }
}
