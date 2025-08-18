using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

public sealed class ListsClient : ClientBase
{
    public ListsClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Gets a paginated list of views for a specific list (collection or set) within a space.
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection or set).</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Number of items to return (default 100).</param>
    /// <returns>A response containing the list views and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ListViewsResponse> GetListViewsAsync(
        string spaceId,
        string listId,
        int offset = 0,
        int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(listId))
        {
            throw new ArgumentNullException(nameof(listId));
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/lists/{listId}/views?offset={offset}&limit={limit}";

        var response = await GetAsync<ListViewsResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
