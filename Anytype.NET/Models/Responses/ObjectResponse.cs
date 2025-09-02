using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API containing an <see cref="Models.AnyObject"/>.
/// </summary>
public sealed class ObjectResponse
{
    /// <summary>
    /// The object.
    /// </summary>
    [JsonPropertyName("object")]
    public AnyObject? AnyObject { get; set; }
}
