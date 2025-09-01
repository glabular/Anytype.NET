using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype properties.
/// </summary>
/// <remarks>⚠ Warning: Properties are experimental and may change in the next update. ⚠</remarks>
public interface IPropertiesApi
{
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
    Task<ListPropertiesResponse> ListAsync(string spaceId, int offset = 0, int limit = 100);

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
    Task<TypeProperty> CreateAsync(string spaceId, CreatePropertyRequest request);

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
    Task<TypeProperty?> GetByIdAsync(string spaceId, string propertyId);

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
    Task<TypeProperty> UpdateAsync(string spaceId, string propertyId, UpdatePropertyRequest request);

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
    Task<TypeProperty> DeleteAsync(string spaceId, string propertyId);

}
