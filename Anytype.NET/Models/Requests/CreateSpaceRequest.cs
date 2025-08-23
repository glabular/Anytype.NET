using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the data required to create a new space.
/// </summary>
public sealed class CreateSpaceRequest
{
    [JsonPropertyName("name")]
    public required string Name { get; set;  }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
