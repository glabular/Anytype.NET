using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class ListTemplatesResponse
{
    [JsonPropertyName("data")]
    public List<Template>? Data { get; set; }

    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
