using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype properties.
/// </summary>
/// <remarks>⚠ Warning: Properties are experimental and may change in the next update. ⚠</remarks>
public sealed class PropertiesClient : ClientBase
{
    public PropertiesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Retrieves a paginated list of properties available within a specific space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list properties for.</param>
    /// <param name="offset">The number of items to skip before starting to collect the result set. Default is 0.</param>
    /// <param name="limit">The number of items to return. Max 1000. Default is 100.</param>
    /// <returns>A <see cref="ListPropertiesResponse"/> containing the list of properties and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<ListPropertiesResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/properties?offset={offset}&limit={limit}";

        var response = await GetAsync<ListPropertiesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
