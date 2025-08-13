using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public class ListMembersResponse
{
    [JsonPropertyName("data")]
    public List<AnyMember> Members { get; set; }

    [JsonPropertyName("pagination")]
    public PaginationMetadata Pagination { get; set; }
}
