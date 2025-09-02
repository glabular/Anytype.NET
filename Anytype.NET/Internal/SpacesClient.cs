using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class SpacesClient : ClientBase, ISpacesApi
{
    private const string RelativeSpacesUrl = "v1/spaces";

    internal SpacesClient(string apiKey) : base(apiKey) { }

    /// <inheritdoc />
    public async Task<SpacesResponse> ListAsync(int offset = 0, int limit = 100)
    {
        if (limit > MaxPaginationLimit)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), $"Limit cannot exceed {MaxPaginationLimit}.");
        }

        var relativeUrl = $"{RelativeSpacesUrl}?offset={offset}&limit={limit}";

        var response = await GetAsync<SpacesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve spaces, response was null.");

        return response;
    }

    /// <inheritdoc />
    public async Task<Space> CreateAsync(CreateSpaceRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var response = await PostAsync<CreateSpaceResponse>(RelativeSpacesUrl, request) 
            ?? throw new InvalidOperationException("Failed to create space, response was null.");

        return response.Space
            ?? throw new InvalidOperationException("Failed to create space, API did not return a valid space.");
    }
        
    /// <inheritdoc />
    public async Task<Space> UpdateAsync(string spaceId, UpdateSpaceRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(request);

        var relativeUrl = $"{RelativeSpacesUrl}/{spaceId}";

        var response = await PatchAsync<SpaceResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("Failed to update space, response was null.");

        return response.Space
            ?? throw new InvalidOperationException("Failed to update space, API did not return a valid space.");
    }

    /// <inheritdoc />
    public async Task<Space?> GetByIdAsync(string spaceId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        var relativeUrl = $"{RelativeSpacesUrl}/{spaceId}";
        var response = await GetAsync<SpaceResponse>(relativeUrl) 
            ?? throw new InvalidOperationException("Failed to get space, response was null.");

        // TODO: Check what returns if space not found and handle accordingly
        return response.Space;
    }
}
