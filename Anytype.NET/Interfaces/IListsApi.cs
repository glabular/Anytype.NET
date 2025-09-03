using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype lists and their views.
/// </summary>
public interface IListsApi
{
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
    Task<ListViewsResponse> ListViewsAsync(string spaceId, string listId, int offset = 0, int limit = 100);

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
    Task<ListObjectsResponse> ListObjectsAsync(
        string spaceId,
        string listId,
        string? viewId,
        int offset = 0,
        int limit = 100);

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
    Task<string> AddObjectsToListAsync(string spaceId, string listId, List<string> objectIds);

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
    Task<string> RemoveObjectFromListAsync(string spaceId, string listId, string objectId);
}
