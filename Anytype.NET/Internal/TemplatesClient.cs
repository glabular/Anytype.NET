using Anytype.NET.Models;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

public sealed class TemplatesClient : ClientBase
{
    public TemplatesClient(string apiKey) : base(apiKey) { }

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

        var relativeUrl = GetUrlPrefix(spaceId, typeId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListTemplatesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve templates, response was null.");

        return response;
    }

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
    public async Task<Template?> GetByIdAsync(string spaceId, string typeId, string templateId)
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

        var relativeUrl = GetUrlPrefix(spaceId, typeId) + $"/{templateId}";

        var response = await GetAsync<GetTemplateResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get template, response was null.");

        return response.Template;
    }

    private static string GetUrlPrefix(string spaceId, string typeId)
    {
        return $"v1/spaces/{spaceId}/types/{typeId}/templates";
    }
}
