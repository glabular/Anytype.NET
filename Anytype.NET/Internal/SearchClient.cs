using Anytype.NET.Interfaces;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class SearchClient : ClientBase, ISearchApi
{
    internal SearchClient(string apiKey) : base(apiKey) { }

    /// <inheritdoc />
    public async Task<SearchResponse> AcrossSpacesAsync(
        SearchRequest request,
        int offset = 0,
        int limit = 100)
    {
        var relativeUrl = $"/v1/search?offset={offset}&limit={limit}";

        return await ExecuteSearchAsync(relativeUrl, request, limit);
    }

    /// <inheritdoc />
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
            ?? throw new InvalidOperationException("Failed to execute search, response was null.");

        return response;
    }
}
