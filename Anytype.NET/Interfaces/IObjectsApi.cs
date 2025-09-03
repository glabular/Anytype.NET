using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype objects.
/// </summary>
public interface IObjectsApi
{
    /// <summary>
    /// Creates a new object.
    /// </summary>
    /// <param name="spaceId">
    /// The ID of the space where the object will be created.
    /// </param>
    /// <param name="createObjectRequest">The data required to create the object.</param>
    /// <returns>The created <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="JsonException"/>
    Task<AnyObject> CreateAsync(string spaceId, CreateObjectRequest createObjectRequest);

    /// <summary>
    /// Gets an object.
    /// </summary>
    /// <param name="getObjectRequest">The request containing SpaceId and ObjectId.</param>
    /// <param name="format">The format to return the object body in. Default is "md".</param>
    /// <returns>The requested <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="JsonException"/>
    Task<AnyObject?> GetByIdAsync(string spaceId, string objectId, string? format = null);

    /// <summary>
    /// Updates the object.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the object to update.</param>
    /// <param name="objectId">The ID of the object to update.</param>
    /// <param name="updateObjectRequest">The data to update on the object.</param>
    /// <returns>The updated <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="JsonException"/>
    Task<AnyObject> UpdateAsync(string spaceId, string objectId, UpdateObjectRequest updateObjectRequest);

    /// <summary>
    /// Deletes (archives) the object.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the object.</param>
    /// <param name="objectId">The ID of the object to delete.</param>
    /// <returns>The deleted (archived) <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<AnyObject> DeleteAsync(string spaceId, string objectId);

    /// <summary>
    /// Gets list of objects in a given space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list objects from.</param>
    /// <param name="offset">The number of items to skip before collecting the result set. Default is 0.</param>
    /// <param name="limit">The number of items to return. Max 1000. Default is 100.</param>
    /// <returns>
    /// A <see cref="ListObjectsResponse"/> containing the objects and pagination metadata.
    /// </returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<ListObjectsResponse> ListAsync(string spaceId, int offset = 0, int limit = 100);
}
