using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype tags.
/// </summary>
public interface ITagsApi
{
    /// <summary>
    /// Gets a list of tags.
    /// </summary>
    /// <param name="spaceId">The ID of the space to list tags for.</param>
    /// <param name="propertyId">The ID of the property to list tags for.</param>
    /// <returns>A <see cref="ListTagsResponse"/> containing the tags and pagination metadata.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<ListTagsResponse> ListAsync(string spaceId, string propertyId);

    /// <summary>
    /// Creates a new tag.
    /// </summary>
    /// <param name="spaceId">The ID of the space to create the tag in.</param>
    /// <param name="propertyId">The ID of the property to create the tag for.</param>
    /// <param name="request">The tag creation data.</param>
    /// <returns>The created <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Tag> CreateAsync(string spaceId, string propertyId, CreateTagRequest request);

    /// <summary>
    /// Gets a tag by ID.
    /// </summary>
    /// <param name="spaceId">The ID of the space to retrieve the tag from.</param>
    /// <param name="propertyId">The ID of the property to retrieve the tag for.</param>
    /// <param name="tagId">The ID of the tag to retrieve.</param>
    /// <returns>The retrieved <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Tag?> GetByIdAsync(string spaceId, string propertyId, string tagId);

    /// <summary>
    /// Updates the tag.
    /// </summary>
    /// <param name="spaceId">The ID of the space to update the tag in.</param>
    /// <param name="propertyId">The ID of the property to update the tag for.</param>
    /// <param name="tagId">The ID of the tag to update.</param>
    /// <param name="request">The update details.</param>
    /// <returns>The updated <see cref="Tag"/> instance.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Tag> UpdateAsync(string spaceId, string propertyId, string tagId, UpdateTagRequest request);

    /// <summary>
    /// Deletes (archives) the tag.
    /// </summary>
    /// <param name="spaceId">The ID of the space to delete the tag from.</param>
    /// <param name="propertyId">The ID of the property to delete the tag for.</param>
    /// <param name="tagId">The ID of the tag to delete.</param>
    /// <returns>The deleted (archived) <see cref="Tag"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Tag> DeleteAsync(string spaceId, string propertyId, string tagId);
}
