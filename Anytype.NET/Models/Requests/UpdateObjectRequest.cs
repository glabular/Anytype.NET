using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the payload to update an existing object in Anytype.
/// </summary>
public sealed class UpdateObjectRequest
{
    /// <summary>
    /// The name (title) of the object.
    /// </summary>
    [JsonPropertyName("name")] 
    public string? Name { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    [JsonPropertyName("icon")]
    public IIcon? Icon { get; set; }

    /// <summary>
    /// A list of properties to set for the object.
    /// </summary>
    /// <remarks>
    /// ⚠ Experimental: Subject to change in future Anytype API updates. ⚠
    /// </remarks>
    [JsonPropertyName("properties")]
    public object[]? Properties { get; set; }
}
