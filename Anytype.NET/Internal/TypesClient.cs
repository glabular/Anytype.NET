using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
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
    /// Gets a list of types.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list types from.</param>
    /// <param name="offset">The number of items to skip before collecting the result set. Default is 0.</param>
    /// <param name="limit">The number of items to return. Max 1000. Default is 100.</param>
    /// <returns>
    /// A <see cref="ListTypeResponse"/> containing the types and pagination metadata.
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

    /// <summary>
    /// Creates a new type.
    /// </summary>
    /// <param name="spaceId">The ID of the space to create the type in.</param>
    /// <param name="request">The type creation data.</param>
    /// <returns>The created <see cref="AnyType"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="JsonException"></exception>
    public async Task<AnyType> CreateAsync(string spaceId, TypeRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var relativeUrl = $"/v1/spaces/{spaceId}/types";

        var response = await PostAsync<TypeResponse>(relativeUrl, request);

        return response?.Type;
    }

    /// <summary>
    /// Deletes (archives) the type.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the type.</param>
    /// <param name="typeId">The ID of the type to delete.</param>
    /// <returns>The deleted (archived) <see cref="AnyType"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<AnyType> DeleteAsync(string spaceId, string typeId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/types/{typeId}";

        var response = await DeleteAsync<TypeResponse>(relativeUrl);

        return response.Type;
    }

    /// <summary>
    /// Get type by ID.
    /// </summary>
    /// <param name="spaceId">The ID of the space to retrieve the type from.</param>
    /// <param name="typeId">The ID of the type to retrieve.</param>
    /// <returns>The retrieved <see cref="AnyType"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<AnyType> GetByIdAsync(string spaceId, string typeId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/types/{typeId}";

        var response = await GetAsync<TypeResponse>(relativeUrl);

        return response.Type;
    }

    /// <summary>
    /// Updates the type.
    /// </summary>
    /// <param name="spaceId">The ID of the space to update the type in.</param>
    /// <param name="typeId">The ID of the type to update.</param>
    /// <param name="request">The update details.</param>
    /// <returns>The updated <see cref="AnyType"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="JsonException"></exception>
    public async Task<AnyType> UpdateAsync(string spaceId, string typeId, TypeRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var relativeUrl = $"/v1/spaces/{spaceId}/types/{typeId}";

        var response = await PatchAsync<TypeResponse>(relativeUrl, request);

        return response?.Type;
    }
}
