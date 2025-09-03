using Anytype.NET.Constants;
using Anytype.NET.Interfaces;
using Anytype.NET.Models.Responses;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <inheritdoc />
internal sealed class AuthClient : IAuthApi
{
    private const string BaseAddress = "http://localhost:31009";
    private const string AuthBaseAddress = "v1/auth";

    private readonly string _apiVersion = AnytypeApiVersions.GetLatest();

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri(BaseAddress)
    };

    internal AuthClient() { }

    /// <inheritdoc />
    public async Task<string> CreateChallengeAsync(string appName)
    {
        if (string.IsNullOrWhiteSpace(appName))
        {
            throw new ArgumentException("App name cannot be null or empty.", nameof(appName));
        }

        var body = new { app_name = appName };
        var response = await PostAsync<ChallengeResponse>($"{AuthBaseAddress}/challenges", body)
            ?? throw new InvalidOperationException("Failed to create challenge, response was null.");

        return response.ChallengeId 
            ?? throw new InvalidOperationException("Failed to create challenge, API did not return a valid challenge.");
    }

    /// <inheritdoc />
    public async Task<string> CreateApiKeyAsync(string challengeId, string code)
    {
        if (string.IsNullOrWhiteSpace(challengeId))
        {
            throw new ArgumentException("Challenge ID cannot be null or empty.", nameof(challengeId));
        }

        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Code cannot be null or empty.", nameof(code));
        }

        var body = new
        {
            challenge_id = challengeId,
            code
        };

        var response = await PostAsync<ApiKeyResponse>($"{AuthBaseAddress}/api_keys", body)
            ?? throw new InvalidOperationException("Failed to create API key, response was null.");

        return response.ApiKey
            ?? throw new InvalidOperationException("Failed to create API key, API did not return a valid API key.");
    }

    private async Task<T?> PostAsync<T>(string relativeUrl, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body, SerializerOptions);

        using var request = new HttpRequestMessage(HttpMethod.Post, relativeUrl)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        };

        request.Headers.Add("Anytype-Version", _apiVersion);

        using var response = await HttpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }
}
