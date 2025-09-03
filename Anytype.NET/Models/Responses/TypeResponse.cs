using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API containing an <see cref="AnyType"/>.
/// </summary>
public sealed class TypeResponse
{
    /// <summary>
    /// The <see cref="AnyType"/> contained in the response body.
    /// </summary>
    [JsonPropertyName("type")]
    public AnyType? Type { get; set; }
}
