using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API containing a <see cref="Tag"/>.
/// </summary>
public sealed class TagResponse
{
    /// <summary>
    /// The tag.
    /// </summary>
    [JsonPropertyName("tag")]
    public Tag? Tag { get; set; }
}
