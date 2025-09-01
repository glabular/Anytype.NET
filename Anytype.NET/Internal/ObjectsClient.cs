using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class ObjectsClient : ClientBase, IObjectsApi
{
    internal ObjectsClient(string apiKey) : base(apiKey) { }

    /// <inheritdoc />
    public async Task<AnyObject> CreateAsync(string spaceId, CreateObjectRequest createObjectRequest)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(createObjectRequest);

        var response = await PostAsync<ObjectResponse>(GetUrlPrefix(spaceId), createObjectRequest)
            ?? throw new InvalidOperationException("Failed to create object, response was null.");

        return response.Object
            ?? throw new InvalidOperationException("Failed to create object, API did not return a valid object.");        
    }

    /// <inheritdoc />    
    public async Task<AnyObject?> GetByIdAsync(string spaceId, string objectId, string? format = null)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(objectId))
        {
            throw new ArgumentException("Object ID cannot be null or whitespace.", nameof(objectId));
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{objectId}";

        if (!string.IsNullOrWhiteSpace(format))
        {
            relativeUrl += $"?format={format}";
        }

        var response = await GetAsync<ObjectResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get object, response was null.");

        return response.Object;
    }

    /// <inheritdoc />
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

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{objectId}";

        var response = await PatchAsync<ObjectResponse>(relativeUrl, updateObjectRequest)
            ?? throw new InvalidOperationException("Failed to update object, response was null.");

        return response.Object
            ?? throw new InvalidOperationException("Failed to update object, API did not return a valid object.");
    }

    /// <inheritdoc />
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

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{objectId}";

        var response = await DeleteAsync<ObjectResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to update object, response was null.");

        return response.Object
            ?? throw new InvalidOperationException("Failed to delete object, API did not return a valid object.");
    }

    /// <inheritdoc />
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

        var relativeUrl = GetUrlPrefix(spaceId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListObjectsResponse>(relativeUrl) 
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }

    /// <summary>
    /// Builds the base relative URL for objects-related endpoints.
    /// </summary>
    private static string GetUrlPrefix(string spaceId)
    {
        return $"v1/spaces/{spaceId}/objects";
    }
}
