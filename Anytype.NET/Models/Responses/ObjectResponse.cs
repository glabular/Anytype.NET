using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents a standard response wrapper containing an <see cref="AnyObject"/> returned by the Anytype API.
/// </summary>
public sealed class ObjectResponse
{
    /// <summary>
    /// The <see cref="AnyObject"/> contained within the response body.
    /// </summary>
    [JsonPropertyName("object")]
    public AnyObject? Object { get; set; }
}
