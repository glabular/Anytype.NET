using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response containing the ID of a one-time authentication challenge.
/// </summary>
public sealed class ChallengeResponse
{
    /// <summary>
    /// The challenge id associated with the displayed code and needed to solve the challenge for api_key.
    /// </summary>
    [JsonPropertyName("challenge_id")]
    public string ChallengeId { get; set; } = string.Empty;
}
