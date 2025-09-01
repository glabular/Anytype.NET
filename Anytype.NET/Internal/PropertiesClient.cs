using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype properties.
/// </summary>
/// <remarks>⚠ Warning: Properties are experimental and may change in the next update. ⚠</remarks>
public sealed class PropertiesClient : ClientBase
{
    public PropertiesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Gets a list of properties.
    /// </summary>
    /// <remarks>⚠ Warning: Properties are experimental and may change in the next update.</remarks>
    /// <param name="spaceId">The ID of the space to list properties for.</param>
    /// <param name="offset">The number of items to skip before starting to collect the result set. Default is 0.</param>
    /// <param name="limit">The number of items to return. Max 1000. Default is 100.</param>
    /// <returns>A <see cref="ListPropertiesResponse"/> containing the list of properties and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<ListPropertiesResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentNullException(nameof(spaceId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListPropertiesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve properties, response was null.");

        return response;
    }

    /// <summary>
    /// Creates a new property.
    /// </summary>
    /// <remarks>⚠ Warning: Properties are experimental and may change in the next update.</remarks>
    /// <param name="spaceId">The ID of the space to create the property in.</param>
    /// <param name="request">The property creation details.</param>
    /// <returns>The created <see cref="TypeProperty"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

    /// <summary>
    /// Gets a property by ID.
    /// </summary>
    /// <remarks>⚠ Warning: Properties are experimental and may change in the next update.</remarks>
    /// <param name="spaceId">The ID of the space to which the property belongs.</param>
    /// <param name="propertyId">The ID of the property to retrieve.</param>
    /// <returns>The retrieved <see cref="TypeProperty"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

    /// <summary>
    /// Deletes (archives) the property.
    /// </summary>
    /// <remarks>⚠ Warning: Properties are experimental and may change in the next update.</remarks>
    /// <param name="spaceId">The ID of the space to which the property belongs.</param>
    /// <param name="propertyId">The ID of the property to delete.</param>
    /// <returns>The deleted (archived) <see cref="TypeProperty"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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

    /// <summary>
    /// Updates the property.
    /// </summary>
    /// <remarks>⚠ Warning: Properties are experimental and may change in the next update.</remarks>
    /// <param name="spaceId">The ID of the space to which the property belongs.</param>
    /// <param name="propertyId">The ID of the property to update.</param>
    /// <param name="request">The update details.</param>
    /// <returns>The updated <see cref="TypeProperty"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
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
