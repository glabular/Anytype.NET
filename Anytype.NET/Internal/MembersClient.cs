using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class MembersClient : ClientBase, IMembersApi
{
    internal MembersClient(string apiKey) : base(apiKey) { }

    /// <inheritdoc />
    public async Task<ListMembersResponse> ListAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"?offset={offset}&limit={limit}";

        var response = await GetAsync<ListMembersResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get members, response was null.");

        return response;
    }

    /// <inheritdoc />
    public async Task<Member?> GetByIdAsync(string spaceId, string memberId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(memberId))
        {
            throw new ArgumentException("Member ID cannot be null or whitespace.", nameof(memberId));
        }

        var relativeUrl = GetUrlPrefix(spaceId) + $"/{memberId}";

        var response = await GetAsync<GetMemberResponse>(relativeUrl)
            ?? throw new InvalidOperationException("Failed to get member, response was null.");

        return response.Member;
    }

    /// <summary>
    /// Builds the base relative URL for members-related endpoints.
    /// </summary>
    private static string GetUrlPrefix(string spaceId)
    {
        return $"v1/spaces/{spaceId}/members";
    }
}
