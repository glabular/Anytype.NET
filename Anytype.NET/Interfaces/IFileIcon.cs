namespace Anytype.NET.Interfaces;

/// <summary>
/// Represents an icon that references a file.
/// </summary>
public interface IFileIcon : IIcon
{
    string File { get; set; }
}
