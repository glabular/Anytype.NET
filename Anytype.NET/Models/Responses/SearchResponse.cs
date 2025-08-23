namespace Anytype.NET.Models.Responses;

public sealed class SearchResponse
{
    public List<SearchItem>? Data { get; set; }

    public PaginationMetadata? Pagination { get; set; }
}
