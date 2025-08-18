using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

public sealed class SearchClient : ClientBase
{
    public SearchClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Executes a global search across all spaces accessible to the authenticated user.
    /// </summary>
    /// <returns>A <see cref="SearchResponse"/> containing matching objects and pagination metadata.</returns>
    /// <param name="request">The search criteria.</param>
    /// <param name="limit">Pagination limit (max 1000).</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<SearchResponse> AcrossSpacesAsync(
        SearchRequest request,
        int offset = 0,
        int limit = 100)
    {
        var relativeUrl = $"/v1/search?offset={offset}&limit={limit}";

        return await ExecuteSearchAsync(relativeUrl, request, limit);
    }

    /// <summary>
    /// Searches objects within a specific space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to search within.</param>
    /// <param name="request">The search criteria.</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Pagination limit (max 1000).</param>
    /// <returns>A <see cref="SearchResponse"/> containing matching objects and pagination metadata.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<SearchResponse> InSpaceAsync(
        string spaceId,
        SearchRequest request,
        int offset = 0,
        int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }        

        var relativeUrl = $"/v1/spaces/{spaceId}/search?offset={offset}&limit={limit}";

        return await ExecuteSearchAsync(relativeUrl, request, limit);
    }

    // TODO: Maybe check the offset for positive value only.
    private async Task<SearchResponse> ExecuteSearchAsync(string relativeUrl, SearchRequest request, int limit)
    {
        const int MaxLimit = 1000;

        if (limit > MaxLimit)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrWhiteSpace(request.Query))
        {
            throw new ArgumentException("Query cannot be null or whitespace.", nameof(request));
        }

        var response = await PostAsync<SearchResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }
}
