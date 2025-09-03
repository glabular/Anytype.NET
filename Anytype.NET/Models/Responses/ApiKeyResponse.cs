using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

/// <summary>
/// Represents the response containing the API key used for authorization in subsequent requests.
/// </summary>
public sealed class ApiKeyResponse
{
    /// <summary>
    /// The api key used to authenticate requests.
    /// </summary>
    [JsonPropertyName("api_key")]
    public string ApiKey { get; set; } = string.Empty;
}
