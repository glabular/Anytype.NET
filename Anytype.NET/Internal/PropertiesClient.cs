using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class PropertiesClient : ClientBase, IPropertiesApi
{
    internal PropertiesClient(string apiKey, string? apiVersion = null)
        : base(apiKey, apiVersion) { }

    /// <inheritdoc />
    public async Task<ListPropertiesResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (limit > MaxPaginationLimit)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), $"Limit cannot exceed {MaxPaginationLimit}.");
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListPropertiesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve properties, response was null.");

        return response;
    }

    /// <inheritdoc />
    public async Task<TypeProperty> CreateAsync(string spaceId, CreatePropertyRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(request);

        var response = await PostAsync<PropertyResponse>(GetUrlPrefix(spaceId), request)
            ?? throw new InvalidOperationException("Failed to create property, response was null.");

        return response.Property
            ?? throw new InvalidOperationException("Failed to create property, API did not return a valid property.");
    }

    /// <inheritdoc />
    public async Task<TypeProperty?> GetByIdAsync(string spaceId, string propertyId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{propertyId}";

        var response = await GetAsync<PropertyResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get property, response was null.");

        return response.Property;
    }

    /// <inheritdoc />
    public async Task<TypeProperty> DeleteAsync(string spaceId, string propertyId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{propertyId}";

        var response = await DeleteAsync<PropertyResponse>(relativeUrl) 
            ?? throw new InvalidOperationException("Failed to delete property, response was null.");

        return response.Property
            ?? throw new InvalidOperationException("Failed to delete property, API did not return a valid property.");
    }

    /// <inheritdoc />
    public async Task<TypeProperty> UpdateAsync(string spaceId, string propertyId, UpdatePropertyRequest request)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(propertyId))
        {
            throw new ArgumentNullException(nameof(propertyId));
        }

        ArgumentNullException.ThrowIfNull(request);

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{propertyId}";

        var response = await PatchAsync<PropertyResponse>(relativeUrl, request) 
            ?? throw new InvalidOperationException("Failed to update property, response was null.");

        return response.Property
            ?? throw new InvalidOperationException("Failed to update property, API did not return a valid property.");
    }

    /// <summary>
    /// Builds the base relative URL for properties-related endpoints.
    /// </summary>
    private static string GetUrlPrefix(string spaceId)
    {
        return $"v1/spaces/{spaceId}/properties";
    }
}
