using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class TypesClient : ClientBase, ITypesApi
{
    internal TypesClient(string apiKey, string? apiVersion = null) 
        : base(apiKey, apiVersion) { }

    public async Task<ListTypeResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (limit > MaxPaginationLimit)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), $"Limit cannot exceed {MaxPaginationLimit}.");
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListTypeResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve types, response was null.");

        return response;
    }

    /// <inheritdoc />
    public async Task<AnyType> CreateAsync(string spaceId, CreateTypeRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var response = await PostAsync<TypeResponse>(GetUrlPrefix(spaceId), request) 
            ?? throw new InvalidOperationException("Failed to create type, response was null.");

        return response.Type
            ?? throw new InvalidOperationException("Failed to create type, API did not return a valid type.");
    }

    /// <inheritdoc />
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

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{typeId}";

        var response = await DeleteAsync<TypeResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to delete type, response was null.");

        return response.Type
            ?? throw new InvalidOperationException("Failed to delete type, API did not return a valid type.");
    }

    /// <inheritdoc />
    public async Task<AnyType?> GetByIdAsync(string spaceId, string typeId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{typeId}";

        var response = await GetAsync<TypeResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get type, response was null.");

        return response.Type;
    }

    /// <inheritdoc />
    public async Task<AnyType> UpdateAsync(string spaceId, string typeId, UpdateTypeRequest request)
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

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{typeId}";

        var response = await PatchAsync<TypeResponse>(relativeUrl, request)
            ?? throw new InvalidOperationException("Failed to update type, response was null.");

        return response.Type
            ?? throw new InvalidOperationException("Failed to update type, API did not return a valid type.");
    }

    /// <summary>
    /// Builds the base relative URL for types-related endpoints.
    /// </summary>
    private static string GetUrlPrefix(string spaceId)
    {
        return $"v1/spaces/{spaceId}/types";
    }
}
