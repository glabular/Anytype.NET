using Anytype.NET.Models;
using System.Text.Json;
using Anytype.NET.Models.Responses;
using System.Collections.Generic;

namespace Anytype.NET.Internal;

public sealed class ListsClient : ClientBase
{    
    internal ListsClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Get a list of views for a specific list (collection or set).
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection or set).</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Number of items to return (default 100).</param>
    /// <returns>A <see cref="ListViewsResponse"/> containing the list views and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

    /// <summary>
    /// Gets the objects for a specific list and view.
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection or set).</param>
    /// <param name="viewId">The ID of the view for filtering and sorting; if null, all objects are returned.</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Number of items to return (default 100).</param>
    /// <returns>A <see cref="ListObjectsResponse"/> response containing a list of objects in the list and pagination metadata.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

    /// <summary>
    /// Adds one or more objects to a specific collection list.
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection) to add objects to.</param>
    /// <param name="objectIds">The list of object IDs to add to the list.</param>
    /// <returns>A confirmation message from the API.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

    /// <summary>
    /// Removes a given object from the specified collection list.
    /// </summary>
    /// <param name="spaceId">The ID of the space the list belongs to.</param>
    /// <param name="listId">The ID of the list (collection) to remove the object from.</param>
    /// <param name="objectId">The ID of the object to remove from the list.</param>
    /// <returns>A confirmation message from the API.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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
