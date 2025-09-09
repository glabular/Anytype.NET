using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// A request payoad to create a new space.
/// </summary>
public sealed class CreateSpaceRequest
{
    /// <summary>
    /// The name of the space.
    /// </summary>
    [JsonPropertyName("name")]    
    public required string Name { get; set;  }

    /// <summary>
    /// The description of the space.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
