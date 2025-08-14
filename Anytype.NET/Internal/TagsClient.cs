using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class TagsClient : ClientBase
{
    public TagsClient(string apiKey) : base(apiKey) { }

    public async Task<ListTagsResponse> ListTagsAsync(string spaceId, string propertyId)
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
