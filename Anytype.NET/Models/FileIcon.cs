using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// An icon represented by a file reference.
/// </summary>
public sealed class FileIcon : IFileIcon
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileIcon"/> class.
    /// </summary>
    public FileIcon(string file)
    {
        File = file ?? throw new ArgumentNullException(nameof(file));
        Format = "file";
    }

    /// <summary>
    /// The file of the icon.
    /// </summary>
    /// <remarks>
    /// Example: bafybeieptz5hvcy6txplcvphjbbh5yjc2zqhmihs3owkh5oab4ezauzqay
    /// </remarks>
    [JsonPropertyName("file")]
    public string File { get; set; }

    /// <summary>
    /// The format of the icon.
    /// </summary>
    [JsonPropertyName("format")]
    public string Format { get ; set ; }
}
