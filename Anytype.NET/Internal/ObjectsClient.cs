using Anytype.NET.Models;
using System.Text.Json;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype objects.
/// </summary>
public class ObjectsClient : ClientBase
{
    public ObjectsClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Creates a new object within the specified space in Anytype.
    /// </summary>
    /// <param name="spaceId">
    /// The unique identifier of the space where the object will be created.
    /// </param>
    /// <param name="createObjectRequest">The data required to create the object.</param>
    /// <returns>The newly created <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="JsonException"/>
    public async Task<AnyObject> CreateObjectAsync(string spaceId, CreateObjectRequest createObjectRequest)
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
    /// Retrieves a single object from a specified space using the Anytype API.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the object.</param>
    /// <param name="objectId">The ID of the object to retrieve.</param>
    /// <returns>The requested <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="JsonException"/>
    public async Task<AnyObject> GetObjectAsync(ObjectRequest getObjectRequest)
    {
        ArgumentNullException.ThrowIfNull(getObjectRequest);

        var response = await GetAsync<ObjectResponse>(
            $"/v1/spaces/{getObjectRequest.SpaceId}/objects/{getObjectRequest.ObjectId}");

        if (response == null || response.Object == null)
        {
            throw new InvalidOperationException("Failed to deserialize the retrieved object.");
        }

        return response.Object;
    }

    /// <summary>
    /// Updates an existing object identified by <paramref name="objectId"/> within 
    /// a specified space identified by <paramref name="spaceId"/> 
    /// using the Anytype API.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the object to update.</param>
    /// <param name="objectId">The ID of the object to update.</param>
    /// <param name="updateObjectRequest">The data to update on the object, including name, icon, and properties.</param>
    /// <returns>The updated <see cref="AnyObject"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="JsonException"/>
    public async Task<AnyObject> UpdateObjectAsync(
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
}
