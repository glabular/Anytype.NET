using System.Text.Json;
using Anytype.NET.Models;
using Anytype.NET.Models.Responses;

namespace Anytype.NET.Internal;

public class MembersClient : ClientBase
{
    public MembersClient(string apiKey) : base(apiKey) { }

    /// <summary>
    /// Retrieves a paginated list of members in the specified space.
    /// </summary>
    /// <param name="spaceId">The space ID to list members for.</param>
    /// <param name="offset">Number of items to skip before collecting the result set (default 0).</param>
    /// <param name="limit">Number of items to return (max 1000, default 100).</param>
    /// <returns>A <see cref="ListMembersResponse"/> with members and pagination info.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    public async Task<ListMembersResponse> ListMembersAsync(string spaceId, int offset = 0, int limit = 100)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (limit > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(limit), "Limit cannot exceed 1000.");
        }

        var relativeUrl = $"/v1/spaces/{spaceId}/members?offset={offset}&limit={limit}";

        var response = await GetAsync<ListMembersResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response;
    }

    /// <summary>
    /// Retrieves a specific member by their ID from the specified space.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the member.</param>
    /// <param name="memberId">The unique ID of the member to retrieve.</param>
    /// <returns>The requested <see cref="AnyMember"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="JsonException"></exception>
    public async Task<AnyMember> GetByIdAsync(string spaceId, string memberId)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        if (string.IsNullOrWhiteSpace(memberId))
        {
            throw new ArgumentException("Member ID cannot be null or whitespace.", nameof(memberId));
        }

        var relativeUrl = $"v1/spaces/{spaceId}/members/{memberId}";

        var response = await GetAsync<GetMemberResponse>(relativeUrl)
            ?? throw new InvalidOperationException("The API returned an empty response.");

        return response.Member;
    }
}
