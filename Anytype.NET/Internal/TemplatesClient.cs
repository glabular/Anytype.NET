using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class TemplatesClient : ClientBase, ITemplatesApi
{
    internal TemplatesClient(string apiKey, string? apiVersion = null)
        : base(apiKey, apiVersion) { }

    /// <inheritdoc />
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

        if (limit > MaxPaginationLimit)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), $"Limit cannot exceed {MaxPaginationLimit}.");
        }

        var relativeUrl = GetUrlPrefix(spaceId, typeId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListTemplatesResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to retrieve templates, response was null.");

        return response;
    }

    /// <inheritdoc />
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

    /// <summary>
    /// Builds the base relative URL for templates-related endpoints.
    /// </summary>
    private static string GetUrlPrefix(string spaceId, string typeId)
    {
        return $"v1/spaces/{spaceId}/types/{typeId}/templates";
    }
}
