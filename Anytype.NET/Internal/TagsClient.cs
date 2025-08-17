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

        var relativeUrl = $"/v1/spaces{spaceId}/properties/{propertyId}/tags";

        var response = await GetAsync<ListTagsResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
