using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to search Anytype entities.
/// </summary>
public interface ISearchApi
{
    /// <summary>
    /// Executes a global search across all spaces in Anytype.
    /// </summary>
    /// <returns>A <see cref="SearchResponse"/> containing matching objects and pagination metadata.</returns>
    /// <param name="request">The search criteria.</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Pagination limit (max 1000).</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<SearchResponse> AcrossSpacesAsync(SearchRequest request, int offset = 0, int limit = 100);

    /// <summary>
    /// Searches objects within a specific Anytype space.
    /// </summary>
    /// <param name="spaceId">The ID of the space to search within.</param>
    /// <param name="request">The search criteria.</param>
    /// <param name="offset">Number of items to skip for pagination (default 0).</param>
    /// <param name="limit">Pagination limit (max 1000).</param>
    /// <returns>A <see cref="SearchResponse"/> containing matching objects and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<SearchResponse> InSpaceAsync(string spaceId, SearchRequest request, int offset = 0, int limit = 100);
}
