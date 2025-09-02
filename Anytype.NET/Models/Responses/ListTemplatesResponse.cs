using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after listing templates.
/// </summary>
public sealed class ListTemplatesResponse
{
    /// <summary>
    /// The list of templates in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<Template>? Data { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
