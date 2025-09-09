using Anytype.NET.Constants;
using Anytype.NET.Converters;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Anytype.NET.Internal;

internal abstract class ClientBase
{
    protected const string BaseAddress = "http://localhost:31009";
    protected const int MaxPaginationLimit = 1000;

    private readonly string _apiKey;
    private readonly string _apiVersion;

    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new IconConverter()
        }
    };

    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri(BaseAddress)
    };

    private protected ClientBase(string apiKey, string? apiVersion = null)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("API key cannot be null or whitespace.", nameof(apiKey));
        }

        _apiKey = apiKey;
        _apiVersion = string.IsNullOrWhiteSpace(apiVersion)
            ? AnytypeApiVersions.GetLatest()
            : apiVersion;
    }

    private protected async Task<T?> GetAsync<T>(string relativeUrl)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, relativeUrl);

        AddDefaultHeaders(request);

        using var response = await HttpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    private protected async Task<T?> PostAsync<T>(string relativeUrl, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body, SerializerOptions);

        using var request = new HttpRequestMessage(HttpMethod.Post, relativeUrl)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        };

        AddDefaultHeaders(request);

        using var response = await HttpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    private protected async Task<T?> PatchAsync<T>(string relativeUrl, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body, SerializerOptions);

        using var request = new HttpRequestMessage(HttpMethod.Patch, relativeUrl)
        {
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        };

        AddDefaultHeaders(request);

        using var response = await HttpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    private protected async Task<T?> DeleteAsync<T>(string relativeUrl)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, relativeUrl);

        AddDefaultHeaders(request);

        using var response = await HttpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    private void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        request.Headers.Add("Anytype-Version", _apiVersion);
    }
}
