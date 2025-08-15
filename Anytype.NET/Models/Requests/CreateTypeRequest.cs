using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Requests;

public sealed class CreateTypeRequest
{
    /// <summary>
    /// The icon of the type (nullable).
    /// </summary>
    [JsonPropertyName("icon")]
    public Icon? Icon { get; set; }

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
    public string Layout { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    [JsonPropertyName("plural_name")]
    public string PluralName { get; set; }

    /// <summary>
    /// The list of properties linked to the type.
    /// ⚠ Experimental and subject to change.
    /// </summary>
    [JsonPropertyName("properties")]
    public List<CreateTypePropertyRequest> Properties { get; set; }
}
