using Anytype.NET.Models;
using System.Text.Json;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype objects.
/// </summary>
public sealed class ObjectsClient : ClientBase
{
    public ObjectsClient(string apiKey) : base(apiKey) { }

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
    public async Task<AnyObject> CreateAsync(string spaceId, CreateObjectRequest createObjectRequest)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(createObjectRequest);

        var response = await PostAsync<ObjectResponse>($"/v1/spaces/{spaceId}/objects", createObjectRequest);

        if (response == null || response.Object == null)
        {
            throw new InvalidOperationException("Failed to deserialize the created object.");
        }

        return response.Object;
    }

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
    public async Task<AnyObject> GetByIdAsync(ObjectRequest getObjectRequest, string? format = null)
    {
        ArgumentNullException.ThrowIfNull(getObjectRequest);

        var relativeUrl = $"/v1/spaces/{getObjectRequest.SpaceId}/objects/{getObjectRequest.ObjectId}";

        if (!string.IsNullOrWhiteSpace(format))
        {
            relativeUrl += $"?format={format}";
        }

        var response = await GetAsync<ObjectResponse>(relativeUrl);

        if (response == null || response.Object == null)
        {
            throw new InvalidOperationException("Failed to deserialize the retrieved object.");
        }

        return response.Object;
    }

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
    public async Task<AnyObject> UpdateAsync(
        string spaceId,
        string objectId,
        UpdateObjectRequest updateObjectRequest)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(objectId)) 
        {
            throw new ArgumentException("Object ID cannot be null or whitespace.", nameof(objectId));
        }

        ArgumentNullException.ThrowIfNull(updateObjectRequest);

        var response = await PatchAsync<ObjectResponse>(
            $"/v1/spaces/{spaceId}/objects/{objectId}", updateObjectRequest);

        if (response == null || response.Object == null)
        {
            throw new InvalidOperationException("Failed to deserialize the updated object.");
        }

        return response.Object;
    }

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
    public async Task<AnyObject> DeleteAsync(string spaceId, string objectId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(objectId))
        {
            throw new ArgumentException("Object ID cannot be null or whitespace.", nameof(objectId));
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/objects/{objectId}";

        var response = await DeleteAsync<ObjectResponse>(relativeUrl);

        if (response == null || response.Object == null)
        {
            throw new InvalidOperationException("Failed to deserialize the deleted object.");
        }

        return response.Object;
    }

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
    public async Task<ListObjectsResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/objects?offset={offset}&limit={limit}";

        var response = await GetAsync<ListObjectsResponse>(relativeUrl) 
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
