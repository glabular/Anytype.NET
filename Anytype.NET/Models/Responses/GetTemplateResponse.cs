using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after creating a template.
/// Contains the created <see cref="Models.Template"/> object if successful.
/// </summary>
public sealed class GetTemplateResponse
{
    /// <summary>
    /// The template.
    /// </summary>
    [JsonPropertyName("template")]
    public Template? Template { get; set; }
}
