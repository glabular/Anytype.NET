using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype spaces.
/// </summary>
public interface ISpacesApi
{
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
    Task<SpacesResponse> ListAsync(int offset = 0, int limit = 100);

    /// <summary>
    /// Creates a new space.
    /// </summary>
    /// <param name="request">The space creation data.</param>
    /// <returns>The created <see cref="Space"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Space> CreateAsync(CreateSpaceRequest request);

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
    Task<Space> UpdateAsync(string spaceId, UpdateSpaceRequest request);

    /// <summary>
    /// Gets a space by ID.
    /// </summary>
    /// <param name="spaceId">The space’s ID.</param>
    /// <returns>The retrieved <see cref="Space"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Space?> GetByIdAsync(string spaceId);
}
