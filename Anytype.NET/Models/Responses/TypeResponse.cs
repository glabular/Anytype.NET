using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class TypeResponse
{
    /// <summary>
    /// The <see cref="AnyType"/> contained within the response body.
    /// </summary>
    [JsonPropertyName("type")]
    public AnyType? Type { get; set; }
}
