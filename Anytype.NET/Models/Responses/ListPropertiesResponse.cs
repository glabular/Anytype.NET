using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class ListPropertiesResponse
{
    /// <summary>
    /// The list of properties in the current result set.
    /// </summary>
    [JsonPropertyName("data")]
    public List<TypeProperty> Properties { get; set; }

    /// <summary>
    /// The pagination metadata for the response.
    /// </summary>
    public PaginationMetadata Pagination { get; set; }
}
