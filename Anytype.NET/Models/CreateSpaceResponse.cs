using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

/// <summary>
/// Represents the response from the API after creating a space.
/// Contains the created <see cref="Models.Space"/> object if successful.
/// </summary>
public class CreateSpaceResponse
{
    [JsonPropertyName("space")]
    public Space? Space { get; set; }
}
