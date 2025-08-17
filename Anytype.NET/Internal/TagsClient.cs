using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class TagsClient : ClientBase
{
    public TagsClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Retrieves a paginated list of tags available for a specific property within a space.
    /// Each tag record includes its unique identifier, name, and color.
    /// This endpoint supports pagination through offset and limit parameters.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list tags for; must be retrieved from ListSpaces endpoint.</param>
    /// <param name="propertyId">The ID of the property to list tags for; must be retrieved from ListProperties endpoint or obtained from response context.</param>
    /// <returns>A <see cref="ListTagsResponse"/> containing the tags and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="spaceId"/> or <paramref name="propertyId"/> is null or whitespace.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the API returns an empty response.</exception>
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
    /// Creates a new tag for the specified property in the specified space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to create the tag in.</param>
    /// <param name="propertyId">The ID of the property to create the tag for.</param>
    /// <param name="request">The tag creation data including name and color.</param>
    /// <returns>The created <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
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

        var relativeUrl = $"/v1/spaces/{spaceId}/properties/{propertyId}/tags";

        var response = await PostAsync<TagResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Tag;
    }
}
