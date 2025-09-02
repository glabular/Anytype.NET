using Anytype.NET.Interfaces;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class ListsClient : ClientBase, IListsApi
{    
    internal ListsClient(string apiKey, string? apiVersion = null)
        : base(apiKey, apiVersion) { }

    /// <inheritdoc />
    public async Task<ListViewsResponse> ListViewsAsync(
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

        var relativeUrl = GetUrlPrefix(spaceId, listId) + $"views?offset={offset}&limit={limit}";

        var response = await GetAsync<ListViewsResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve views, response was null.");

        return response;
    }

    /// <inheritdoc />
    public async Task<ListObjectsResponse> ListObjectsAsync(
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

        var relativeUrl = GetUrlPrefix(spaceId, listId) + $"views/{viewSegment}/objects?offset={offset}&limit={limit}";

        var response = await GetAsync<ListObjectsResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve objects, response was null.");

        return response;
    }

    /// <inheritdoc />
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

        var relativeUrl = GetUrlPrefix(spaceId, listId) + "objects";
        var payload = new { objects = objectIds };
        var response = await PostAsync<string>(relativeUrl, payload)
            ?? throw new InvalidOperationException("Failed to add objects, response was null.");

        return response;
    }

    /// <inheritdoc />
    public async Task<string> RemoveObjectFromListAsync(
        string spaceId,
        string listId,
        string objectId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null, empty, or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(listId))
        {
            throw new ArgumentException("List ID cannot be null, empty, or whitespace.", nameof(listId));
        }

        if (string.IsNullOrWhiteSpace(objectId))
        {
            throw new ArgumentException("Object ID cannot be null, empty, or whitespace.", nameof(objectId));
        }

        var relativeUrl = GetUrlPrefix(spaceId, listId) + $"objects/{objectId}";

        var response = await DeleteAsync<string>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to remove object, response was null.");

        return response;
    }

    /// <summary>
    /// Builds the base relative URL for lists-related endpoints.
    /// </summary>    
    private static string GetUrlPrefix(string spaceId, string listId)
    {
        return $"v1/spaces/{spaceId}/lists/{listId}/";
    }
}
