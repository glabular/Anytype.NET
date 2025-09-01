using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class TagsClient : ClientBase, ITagsApi
{
    internal TagsClient(string apiKey) : base(apiKey) { }

    /// <inheritdoc />
    public async Task<ListTagsResponse> ListAsync(string spaceId, string propertyId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        // NB: According to the official API docs, offset and limit parameters are not specified for this endpoint (API ver. 2025-05-20)
        
        var response = await GetAsync<ListTagsResponse>(GetUrlPrefix(spaceId, propertyId))
            ?? throw new InvalidOperationException("Failed to retrieve tags, response was null");

        return response;
    }

    /// <inheritdoc />
    public async Task<Tag> CreateAsync(string spaceId, string propertyId, CreateTagRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        ArgumentNullException.ThrowIfNull(request);

        var response = await PostAsync<TagResponse>(GetUrlPrefix(spaceId, propertyId), request)
            ?? throw new InvalidOperationException("Failed to create tag, response was null.");

        return response.Tag
            ?? throw new InvalidOperationException("Failed to create tag, API did not return a valid tag.");
    }

    /// <inheritdoc />
    public async Task<Tag?> GetByIdAsync(string spaceId, string propertyId, string tagId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        if (string.IsNullOrWhiteSpace(tagId))
        {
            throw new ArgumentNullException(nameof(tagId));
        }

        // NB! The API seems to ignore the propertyId parameter and just returns 
        // the tag by tagId alone. Even if I pass a wrong or fake propertyId, 
        // I'll still get the tag as long as the tagId is correct. 
        // Looks like the server isn't actually checking if the property and tag are related,
        // despite that propertyId is required by the documentation.
        var relativeUrl = GetUrlPrefix(spaceId, propertyId) + $"/{tagId}";

        var response = await GetAsync<TagResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get tag, response was null.");

        return response.Tag;
    }

    /// <inheritdoc />
    public async Task<Tag> UpdateAsync(string spaceId, string propertyId, string tagId, UpdateTagRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        if (string.IsNullOrWhiteSpace(tagId))
        {
            throw new ArgumentNullException(nameof(tagId));
        }

        ArgumentNullException.ThrowIfNull(request);

        var relativeUrl = GetUrlPrefix(spaceId, propertyId) + $"/{tagId}";

        var response = await PatchAsync<TagResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("Failed to update tag, response was null.");

        return response.Tag
            ?? throw new InvalidOperationException("Failed to update tag, API did not return a valid tag.");
    }

    /// <inheritdoc />
    public async Task<Tag> DeleteAsync(string spaceId, string propertyId, string tagId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        if (string.IsNullOrWhiteSpace(tagId))
        {
            throw new ArgumentNullException(nameof(tagId));
        }

        var relativeUrl = GetUrlPrefix(spaceId, propertyId) + $"/{tagId}";

        var response = await DeleteAsync<TagResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to delete tag, response was null.");

        return response.Tag 
            ?? throw new InvalidOperationException("Failed to delete tag, API did not return a valid tag.");
    }

    /// <summary>
    /// Builds the base relative URL for tags-related endpoints.
    /// </summary>
    private static string GetUrlPrefix(string spaceId, string propertyId)
    {
        return $"v1/spaces/{spaceId}/properties/{propertyId}/tags";
    }
}
