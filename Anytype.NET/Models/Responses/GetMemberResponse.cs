using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response from the API after creating a member.
/// Contains the created <see cref="Models.Member"/> object if successful.
/// </summary>
public sealed class GetMemberResponse
{
    /// <summary>
    /// The member.
    /// </summary>
    [JsonPropertyName("member")]
    public Member? Member { get; set; }
}
