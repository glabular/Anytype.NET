using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public class SpacesResponse
{
    [JsonPropertyName("data")]
    public List<Space>? Spaces { get; set; }

    [JsonPropertyName("pagination")]
    public SpacesPagination? Pagination { get; set; }
}
