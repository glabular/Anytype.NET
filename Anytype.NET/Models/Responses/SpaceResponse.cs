using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API containing a <see cref="Space"/>.
/// </summary>
public sealed class SpaceResponse
{
    /// <summary>
    /// The space.
    /// </summary>
    [JsonPropertyName("space")]
    public Space? Space { get; set; }
}
