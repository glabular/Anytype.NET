using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class TagsClient : ClientBase
{
    public TagsClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Gets a list of tags.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list tags for.</param>
    /// <param name="propertyId">The ID of the property to list tags for.</param>
    /// <returns>A <see cref="ListTagsResponse"/> containing the tags and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

        // NB: According to the official API docs, offset and limit parameters are not specified for this endpoint.
        var relativeUrl = $"/v1/spaces/{spaceId}/properties/{propertyId}/tags";

        var response = await GetAsync<ListTagsResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }

    /// <summary>
    /// Creates a new tag.
    /// </summary>
    /// <param name="spaceId">The ID of the space to create the tag in.</param>
    /// <param name="propertyId">The ID of the property to create the tag for.</param>
    /// <param name="request">The tag creation data.</param>
    /// <returns>The created <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<Tag> CreateAsync(string spaceId, string propertyId, TagRequest request)
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

        var relativeUrl = $"/v1/spaces/{spaceId}/properties/{propertyId}/tags";

        var response = await PostAsync<TagResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Tag;
    }

    /// <summary>
    /// Gets a tag by ID.
    /// </summary>
    /// <param name="spaceId">The ID of the space to retrieve the tag from.</param>
    /// <param name="propertyId">The ID of the property to retrieve the tag for.</param>
    /// <param name="tagId">The ID of the tag to retrieve.</param>
    /// <returns>The retrieved <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<Tag> GetByIdAsync(string spaceId, string propertyId, string tagId)
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
        var relativeUrl = $"/v1/spaces/{spaceId}/properties/{propertyId}/tags/{tagId}";

        var response = await GetAsync<TagResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Tag;
    }

    /// <summary>
    /// Updates the tag.
    /// </summary>
    /// <param name="spaceId">The ID of the space to update the tag in.</param>
    /// <param name="propertyId">The ID of the property to update the tag for.</param>
    /// <param name="tagId">The ID of the tag to update.</param>
    /// <param name="request">The update details.</param>
    /// <returns>The updated <see cref="Tag"/> instance.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<Tag> UpdateAsync(string spaceId, string propertyId, string tagId, TagRequest request)
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

        var relativeUrl = $"/v1/spaces/{spaceId}/properties/{propertyId}/tags/{tagId}";

        var response = await PatchAsync<TagResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Tag;
    }

    /// <summary>
    /// Deletes (archives) the tag.
    /// </summary>
    /// <param name="spaceId">The ID of the space to delete the tag from.</param>
    /// <param name="propertyId">The ID of the property to delete the tag for.</param>
    /// <param name="tagId">The ID of the tag to delete.</param>
    /// <returns>The deleted (archived) <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

        var relativeUrl = $"/v1/spaces/{spaceId}/properties/{propertyId}/tags/{tagId}";

        var response = await DeleteAsync<TagResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Tag;
    }
}
