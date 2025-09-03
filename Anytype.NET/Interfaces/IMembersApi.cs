using Anytype.NET.Models;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype members.
/// </summary>
public interface IMembersApi
{
    /// <summary>
    /// Gets a list of members in the specified space.
    /// </summary>
    /// <param name="spaceId">The space ID to list members for.</param>
    /// <param name="offset">Number of items to skip before collecting the result set (default 0).</param>
    /// <param name="limit">Number of items to return (max 1000, default 100).</param>
    /// <returns>A <see cref="ListMembersResponse"/> containing the members and pagination metadata.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"/>
    Task<ListMembersResponse> ListAsync(string spaceId, int offset = 0, int limit = 100);

    /// <summary>
    /// Gets a member by ID.
    /// </summary>
    /// <param name="spaceId">The ID of the space containing the member.</param>
    /// <param name="memberId">The ID of the member to retrieve.</param>
    /// <returns>The requested <see cref="Member"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="JsonException"></exception>
    Task<Member?> GetByIdAsync(string spaceId, string memberId);
}
