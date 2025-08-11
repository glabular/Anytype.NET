using Anytype.NET.Converters;
using Anytype.NET.Models.Enums;
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
            new SnakeCaseEnumConverter<PropertyKey>()
        }
    };
    protected readonly HttpClient HttpClient;

    protected ClientBase(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        HttpClient = new HttpClient
        {
            BaseAddress = new Uri(BaseAddress)
        };

        HttpClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", _apiKey);
        HttpClient.DefaultRequestHeaders.Add("Anytype-Version", AnytypeVersion);
    }

    protected async Task<T?> GetAsync<T>(string relativeUrl)
    {
        using var response = await HttpClient.GetAsync(relativeUrl);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    protected async Task<T?> PostAsync<T>(string relativeUrl, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body, SerializerOptions);
        using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await HttpClient.PostAsync(relativeUrl, content);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    protected async Task<T?> PatchAsync<T>(string relativeUrl, object body)
    {
        var jsonContent = JsonSerializer.Serialize(body, SerializerOptions);
        using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(HttpMethod.Patch, relativeUrl)
        {
            Content = content
        };

        using var response = await HttpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }

    protected async Task<T?> DeleteAsync<T>(string relativeUrl)
    {
        using var response = await HttpClient.DeleteAsync(relativeUrl);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json, SerializerOptions);
    }
}
