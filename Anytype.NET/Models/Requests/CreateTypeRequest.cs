using Anytype.NET.Interfaces;
using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// A request payload for creating a new type.
/// </summary>
public sealed class CreateTypeRequest
{
#pragma warning disable CS8618

    /// <summary>
    /// The icon of the type.
    /// </summary>
    [JsonPropertyName("icon")]
    public IIcon? Icon { get; set; }

    /// <summary>
    /// The key of the type.
    /// </summary>
    /// <remarks>Should always be snake_case, otherwise it will be converted to snake_case.</remarks>
    [JsonPropertyName("key")]
    public string Key { get; set; }

    /// <summary>
    /// The layout of the type. Possible values: basic, profile, action, note.
    /// </summary>
    [JsonPropertyName("layout")]
    public required string Layout { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    [JsonPropertyName("plural_name")]
    public required string PluralName { get; set; }

#pragma warning disable CS8618
    /// <summary>
    /// The list of properties linked to the type.
    /// ⚠ Experimental and subject to change.
    /// </summary>
    [JsonPropertyName("properties")]
    public List<TypePropertyRequest> Properties { get; set; }

#pragma warning restore CS8618
}
