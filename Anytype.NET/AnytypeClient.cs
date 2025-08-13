using Anytype.NET.Internal;

namespace Anytype.NET;

/// <summary>
/// The main client for interacting with the Anytype API.
/// </summary>
public class AnytypeClient
{
    private readonly string _apiKey;

    /// <summary>
    /// Initializes a new instance of <see cref="AnytypeClient"/> with the given API key.
    /// </summary>
    /// <param name="apiKey">The API key for authentication.</param>
    /// <exception cref="ArgumentNullException"/>
    public AnytypeClient(string apiKey)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        Spaces = new SpacesClient(_apiKey);
        Objects = new ObjectsClient(_apiKey);
        Members = new MembersClient(_apiKey);
    }

    public SpacesClient Spaces { get; }

    public ObjectsClient Objects { get; }

    public MembersClient Members { get; }
}
