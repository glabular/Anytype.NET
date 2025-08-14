using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype types.
/// </summary>
public sealed class TypesClient : ClientBase
{
    public TypesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Retrieves a paginated list of types available within the specified space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list types from.</param>
    /// <param name="offset">The number of items to skip before collecting the result set. Default is 0.</param>
    /// <param name="limit">The number of items to return. Max 1000. Default is 100.</param>
    /// <returns>
    /// A <see cref="ListTypeResponse"/> containing the retrieved types and associated pagination metadata.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="JsonException"></exception>
    public async Task<ListTypeResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/types?offset={offset}&limit={limit}";

        var response = await GetAsync<ListTypeResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
