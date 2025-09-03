using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the data required to update an existing space.
/// </summary>
/// <remarks>
/// The request body should contain the new name and/or description in JSON format.
/// </remarks>
public sealed class UpdateSpaceRequest
{
#pragma warning disable CS8618
    /// <summary>
    /// The name of the space.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The description of the space.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

#pragma warning restore CS8618
}
