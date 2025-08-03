using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anytype.NET;

public class AnytypeClient
{
    private const string BaseAddress = "http://localhost:31009";
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter(
                JsonNamingPolicy.CamelCase, 
                allowIntegerValues: false),
        }
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
    /// Retrieves a simplified list of all accessible spaces.
    /// </summary>
    /// <returns>A list of <see cref="Space"/> objects (or empty list if none are found).</returns>
    /// <exception cref="HttpRequestException"/>
    /// <exception cref="JsonException"></exception>
    /// <exception cref="InvalidOperationException"/>
    /// <exception cref="Exception"/>
    public async Task<List<Space>> GetSpacesAsync()
    {
        try
        {
            var response = await GetSpacesDetailedAsync();
            var spaces = response.Spaces;

            return spaces ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves detailed space data.
    /// </summary>
    /// <returns>A <see cref="SpacesResponse"/> containing the list of Spaces and additional response data.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails or returns a non-success status code.</exception>
    /// <exception cref="JsonException">Thrown when the response cannot be parsed into a <see cref="SpacesResponse"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the deserialized response is null or invalid.</exception>
    public async Task<SpacesResponse> GetSpacesDetailedAsync()
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/v1/spaces");

            request.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var statusCode = (int)response.StatusCode;
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"Request to Anytype API failed with status code {statusCode}. Response: {content}",
                    null,
                    response.StatusCode);
            }

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

    /// <summary>
    /// Creates a new space.
    /// </summary>
    /// <param name="createSpaceRequest">
    /// An object containing the name and description of the space to create.
    /// </param>
    /// <returns>
    /// The newly created <see cref="Space"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="createSpaceRequest"/> is null.</exception>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails or returns a non-success status code.</exception>
    /// <exception cref="JsonException">Thrown when the response cannot be parsed into a <see cref="Space"/> object.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the deserialized <see cref="Space"/> object is null.</exception>
    /// <exception cref="Exception">Thrown when an unexpected error occurs during the request or processing.</exception>
    public async Task<Space> CreateSpaceAsync(CreateSpaceRequest createSpaceRequest)
    {
        ArgumentNullException.ThrowIfNull(createSpaceRequest);

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseAddress}/v1/spaces");

            request.Headers.Add("Authorization", $"Bearer {_apiKey}");

            var json = JsonSerializer.Serialize(createSpaceRequest);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var statusCode = (int)response.StatusCode;
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"Request to Anytype API failed with status code {statusCode}. Response: {content}",
                    null,
                    response.StatusCode);
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var wrapper = JsonSerializer.Deserialize<CreateSpaceResponse>(responseBody, _serializerOptions);

            if (wrapper == null || wrapper.Space == null)
            {
                throw new InvalidOperationException("Failed to deserialize the created Space.");
            }

            return wrapper.Space;
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

    /// <summary>
    /// Creates a new object within the specified space in Anytype.
    /// </summary>
    /// <param name="spaceId">
    /// The unique identifier of the space where the object will be created.
    /// </param>
    public async Task<AnyObject> CreateObject(string spaceId, CreateObjectRequest createObjectRequest)
    {
        if (string.IsNullOrWhiteSpace(spaceId))
        {
            throw new ArgumentException("Space ID cannot be null or whitespace.", nameof(spaceId));
        }

        ArgumentNullException.ThrowIfNull(createObjectRequest);

        try
        {
            var request = new HttpRequestMessage(
                HttpMethod.Post, 
                $"{BaseAddress}/v1/spaces/{spaceId}/objects");

            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            request.Headers.Add("Anytype-Version", "2025-05-20");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonSerializer.Serialize(createObjectRequest, _serializerOptions);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var statusCode = (int)response.StatusCode;
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"Request to Anytype API failed with status code {statusCode}. Response: {content}",
                    null,
                    response.StatusCode);
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var wrapper = JsonSerializer.Deserialize<CreateObjectResponse>(responseBody, _serializerOptions);

            if (wrapper == null || wrapper.Object == null)
            {
                throw new InvalidOperationException("Failed to deserialize the created object.");
            }

            return wrapper.Object;

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
