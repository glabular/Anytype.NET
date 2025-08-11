using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public class SpacesClient : ClientBase
{
    private const string RelativeSpacesUrl = "/v1/spaces";

    public SpacesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Retrieves a simplified list of all accessible spaces.
    /// </summary>
    /// <returns>A list of <see cref="Space"/> objects.</returns>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"></exception>
    /// <exception cref="InvalidOperationException"/>
    public async Task<List<Space>?> GetSpacesAsync()
    {
        var response = await GetAsync<SpacesResponse>(RelativeSpacesUrl);

        return response?.Spaces;
    }

    /// <summary>
    /// Retrieves detailed space data.
    /// </summary>
    /// <returns>A <see cref="SpacesResponse"/> containing the list of Spaces and additional response data.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails or returns a non-success status code.</exception>
    /// <exception cref="JsonException">Thrown when the response cannot be parsed into a <see cref="SpacesResponse"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the deserialized response is null or invalid.</exception>
    public async Task<SpacesResponse?> GetSpacesDetailedAsync()
    {
        return await GetAsync<SpacesResponse>(RelativeSpacesUrl);
    }

    /// <summary>
    /// Creates a new space.
    /// </summary>
    /// <param name="createSpaceRequest">
    /// An object containing the name and description of the space to create.
    /// </param>
    /// <returns>
    /// The newly created <see cref="Space"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="JsonException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<Space?> CreateSpaceAsync(CreateSpaceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var response = await PostAsync<CreateSpaceResponse>(RelativeSpacesUrl, request) 
            ?? throw new InvalidOperationException("Failed to create space, response was null.");

        return response?.Space;
    }

    /// <summary>
    /// Updates the name and/or description of an existing space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to update.</param>
    /// <param name="request">The updated name and/or description of the space.</param>
    /// <returns>The updated <see cref="Space"/>.</returns>
    public async Task<Space?> UpdateSpaceAsync(string spaceId, UpdateSpaceRequest request)
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
    /// Gets a space by its ID.
    /// </summary>
    /// <param name="spaceId">The space’s ID.</param>
    /// <returns>The requested <see cref="Space"/>.</returns>
    public async Task<Space?> GetSpaceAsync(string spaceId)
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
