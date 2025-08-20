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

    /// <summary>
    /// Gets a paginated list of objects associated with a specific list and view within a space.
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection or set).</param>
    /// <param name="viewId">The ID of the view for filtering and sorting; if null, all objects are returned.</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Number of items to return (default 100).</param>
    /// <returns>A response containing pagination data and list objects as AnyObject instances.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ListObjectsResponse> GetListObjectsAsync(
        string spaceId,
        string listId,
        string? viewId,
        int offset = 0,
        int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null, empty, or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(listId))
        {
            throw new ArgumentException("List ID cannot be null, empty, or whitespace.", nameof(listId));
        }

        // ViewId can be omitted to retrieve all objects in the list.
        var viewSegment = string.IsNullOrWhiteSpace(viewId) ? string.Empty : viewId;
        var relativeUrl = $"/v1/spaces/{spaceId}/lists/{listId}/views/{viewSegment}/objects?offset={offset}&limit={limit}";

        var response = await GetAsync<ListObjectsResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }

    /// <summary>
    /// Adds one or more objects to a specific collection list.
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection) to add objects to.</param>
    /// <param name="objectIds">The list of object IDs to add to the list.</param>
    /// <returns>A confirmation message from the API.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public async Task<string> AddObjectsToListAsync(
        string spaceId,
        string listId,
        List<string> objectIds)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null, empty, or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(listId))
        {
            throw new ArgumentException("List ID cannot be null, empty, or whitespace.", nameof(listId));
        }

        if (objectIds == null || objectIds.Count == 0)
        {
            throw new ArgumentException("Object IDs list cannot be null or empty.", nameof(objectIds));
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/lists/{listId}/objects";
        var payload = new { objects = objectIds };
        var response = await PostAsync<string>(relativeUrl, payload)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }


}
