using System.Text.Json;
using Anytype.NET.Models;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype templates.
/// </summary>
public interface ITemplatesApi
{
    /// <summary>
    /// Gets a list of templates.
    /// </summary>
    /// <param name="spaceId">The unique identifier of the space containing the templates.</param>
    /// <param name="typeId">The unique identifier of the type to filter templates by.</param>
    /// <param name="offset">The zero-based index of the first template to retrieve.</param>
    /// <param name="limit">The maximum number of templates to retrieve per request.</param>
    /// <returns>
    /// A <see cref="ListTemplatesResponse"/> containing the templates and pagination metadata.
    /// </returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/> 
    Task<ListTemplatesResponse> ListAsync(string spaceId, string typeId, int offset = 0, int limit = 100);

    /// <summary>
    /// Gets a template by ID.
    /// </summary>
    /// <param name="spaceId">The space ID where the template belongs.</param>
    /// <param name="typeId">The type ID that the template is associated with.</param>
    /// <param name="templateId">The template ID to retrieve.</param>
    /// <returns>The requested <see cref="Template"/>.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<Template?> GetByIdAsync(string spaceId, string typeId, string templateId);
}
