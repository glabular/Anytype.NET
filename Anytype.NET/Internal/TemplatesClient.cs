using Anytype.NET.Models.Responses;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class TemplatesClient : ClientBase
{
    public TemplatesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Lists templates associated with the specified type in a space.
    /// </summary>
    /// <returns>
    /// A <see cref="ListTemplatesResponse"/> containing the retrieved templates and associated pagination metadata.
    /// </returns> 
    public async Task<ListTemplatesResponse> ListAsync(string spaceId, string typeId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/types/{typeId}/templates?offset={offset}&limit={limit}";

        var response = await GetAsync<ListTemplatesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
