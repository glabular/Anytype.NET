using Anytype.NET.Converters;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Anytype.NET.Internal;

public abstract class ClientBase
{
    protected const string BaseAddress = "http://localhost:31009";
    protected const string AnytypeVersion = "2025-05-20";
    private readonly string _apiKey;
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new IconConverter()
        }
    };
    protected static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri(BaseAddress)
    };

    protected ClientBase(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
    }

    protected async Task<T?> GetAsync<T>(string relativeUrl)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, relativeUrl);

        AddDefaultHeaders(request);

        using var response = await HttpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    protected async Task<T?> PostAsync<T>(string relativeUrl, object body)
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

    protected async Task<T?> PatchAsync<T>(string relativeUrl, object body)
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

    protected async Task<T?> DeleteAsync<T>(string relativeUrl)
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
        request.Headers.Add("Anytype-Version", AnytypeVersion);
    }
}
