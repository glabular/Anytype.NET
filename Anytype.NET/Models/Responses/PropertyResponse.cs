using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API containing a <see cref="TypeProperty"/>.
/// </summary>
public sealed class PropertyResponse
{
    /// <summary>
    /// The property.
    /// </summary>
    [JsonPropertyName("property")]
    public TypeProperty? Property { get; set; }
}
