using Anytype.NET.Models;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

public sealed class TemplatesClient : ClientBase
{
    public TemplatesClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Retrieves a paginated list of templates associated with the specified type within a given space.
    /// </summary>
    /// <param name="spaceId">The unique identifier of the space containing the templates.</param>
    /// <param name="typeId">The unique identifier of the type to filter templates by.</param>
    /// <param name="offset">The zero-based index of the first template to retrieve.</param>
    /// <param name="limit">The maximum number of templates to retrieve per request.</param>
    /// <returns>
    /// A <see cref="ListTemplatesResponse"/> containing templates and their associated pagination metadata.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>    
    public async Task<ListTemplatesResponse> ListAsync(string spaceId, string typeId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/types/{typeId}/templates?offset={offset}&limit={limit}";

        var response = await GetAsync<ListTemplatesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }

    /// <summary>
    /// Gets a template by its ID.
    /// </summary>
    /// <param name="spaceId">The space ID where the template belongs.</param>
    /// <param name="typeId">The type ID that the template is associated with.</param>
    /// <param name="templateId">The template ID to retrieve.</param>
    /// <returns>The requested <see cref="Template"/>.</returns>
    public async Task<Template> GetByIdAsync(string spaceId, string typeId, string templateId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(typeId))
        {
            throw new ArgumentException("Type ID cannot be null or whitespace.", nameof(typeId));
        }

        if (string.IsNullOrWhiteSpace(templateId))
        {
            throw new ArgumentException("Template ID cannot be null or whitespace.", nameof(templateId));
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/types/{typeId}/templates/{templateId}";

        var response = await GetAsync<GetTemplateResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Template;
    }
}
