using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after creating a space.
/// Contains the created <see cref="Models.Space"/> object if successful.
/// </summary>
public sealed class CreateSpaceResponse
{
    /// <summary>
    /// The space.
    /// </summary>
    [JsonPropertyName("space")]
    public Space? Space { get; set; }
}
