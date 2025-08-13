using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// An icon represented by a file reference.
/// </summary>
public sealed class FileIcon : Icon
{
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
}
