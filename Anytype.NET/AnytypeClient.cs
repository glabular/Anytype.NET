using Anytype.NET.Models;
using System.Text.Json;

namespace Anytype.NET;

public class AnytypeClient
{
    private const string BaseAddress = "http://localhost:31009";
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// Client for accessing Anytype API endpoints.
    /// Initializes a new instance of <see cref="AnytypeClient"/> with the given API key.
    /// </summary>
    /// <param name="apiKey">The API key for authentication.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="apiKey"/> is null.</exception>
    public AnytypeClient(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Gets the list of spaces asynchronously.
    /// </summary>
    /// <returns>A list of <see cref="Space"/> objects (or empty list if no spaces are found).</returns>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"></exception>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="Exception"/>
    public async Task<List<Space>> GetSpacesAsync()
    {
        try
        {
            var response = await GetSpacesResponseAsync();
            var spaces = response.Spaces;

            return spaces ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Sends a request to the /spaces endpoint.
    /// </summary>
    /// <returns>A <see cref="SpacesResponse"/> containing the list of Spaces and additional response data.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails or returns a non-success status code.</exception>
    /// <exception cref="JsonException">Thrown when the response cannot be parsed into a <see cref="SpacesResponse"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the deserialized response is null or invalid.</exception>
    public async Task<SpacesResponse> GetSpacesResponseAsync()
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/v1/spaces");

            request.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var spacesResponse = JsonSerializer.Deserialize<SpacesResponse>(responseBody, _serializerOptions);

            return spacesResponse ?? throw new InvalidOperationException("Failed to deserialize SpacesResponse.");
        }
        catch (HttpRequestException ex)
        {
            throw new Exception("Error occurred while sending request to Anytype API.", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception("Error occurred while parsing response from Anytype API.", ex);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
