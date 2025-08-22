using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class SpacesClient : ClientBase
{
    private const string RelativeSpacesUrl = "/v1/spaces";

    public SpacesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Gets a list of spaces.
    /// </summary>
    /// <param name="offset">The number of items to skip before starting to collect the result set (default: 0).</param>
    /// <param name="limit">The number of items to return (default: 100, maximum: 1000).</param>
    /// <returns>A <see cref="SpacesResponse"/> containing the spaces and pagination metadata.</returns>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<SpacesResponse?> ListAsync(int offset = 0, int limit = 100)
    {
        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"{RelativeSpacesUrl}?offset={offset}&limit={limit}";

        var response = await GetAsync<SpacesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }

    /// <summary>
    /// Creates a new space.
    /// </summary>
    /// <param name="request">The space creation data.</param>
    /// <returns>The created <see cref="Space"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<Space?> CreateAsync(CreateSpaceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var response = await PostAsync<CreateSpaceResponse>(RelativeSpacesUrl, request) 
            ?? throw new InvalidOperationException("Failed to create space, response was null.");

        return response?.Space;
    }

    /// <summary>
    /// Updates the space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to update.</param>
    /// <param name="request">The update details.</param>
    /// <returns>The updated <see cref="Space"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<Space?> UpdateAsync(string spaceId, UpdateSpaceRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(request);

        var relativeUrl = $"{RelativeSpacesUrl}/{spaceId}";

        var response = await PatchAsync<SpaceResponse>(relativeUrl, request);

        return response?.Space;
    }

    /// <summary>
    /// Gets a space by ID.
    /// </summary>
    /// <param name="spaceId">The space’s ID.</param>
    /// <returns>The retrieved <see cref="Space"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<Space?> GetByIdAsync(string spaceId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        var relativeUrl = $"{RelativeSpacesUrl}/{spaceId}";
        var response = await GetAsync<SpaceResponse>(relativeUrl);

        return response?.Space;
    }
}
