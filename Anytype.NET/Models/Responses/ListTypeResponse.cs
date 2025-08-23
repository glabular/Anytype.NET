using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class ListTypeResponse
{
    [JsonPropertyName("data")]
    public List<AnyType>? Data { get; set; }

    [JsonPropertyName("pagination")]
    public PaginationMetadata? Pagination { get; set; }
}
