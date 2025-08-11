using Anytype.NET.Internal;

namespace Anytype.NET;

public class AnytypeClient
{
    private readonly string _apiKey;

    /// <summary>
    /// Client for accessing Anytype API endpoints.
    /// Initializes a new instance of <see cref="AnytypeClient"/> with the given API key.
    /// </summary>
    /// <param name="apiKey">The API key for authentication.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="apiKey"/> is null.</exception>
    public AnytypeClient(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        Spaces = new SpacesClient(_apiKey);
        Objects = new ObjectsClient(_apiKey);
    }

    public SpacesClient Spaces { get; }

    public ObjectsClient Objects { get; }
}
