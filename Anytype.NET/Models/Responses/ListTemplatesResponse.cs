namespace Anytype.NET.Models.Responses;

public sealed class ListTemplatesResponse
{
    public List<Template> Data { get; set; }

    public PaginationMetadata Pagination { get; set; }
}
