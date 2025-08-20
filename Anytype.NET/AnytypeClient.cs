using Anytype.NET.Internal;

namespace Anytype.NET;

/// <summary>
/// The main client for interacting with the Anytype API.
/// </summary>
public sealed class AnytypeClient
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
        Types = new TypesClient(_apiKey);
        Templates = new TemplatesClient(_apiKey);
        Tags = new TagsClient(_apiKey);
        Properties = new PropertiesClient(_apiKey);
        Search = new SearchClient(_apiKey);
        Lists = new ListsClient(_apiKey);
    }

    public SpacesClient Spaces { get; }

    public ObjectsClient Objects { get; }

    public MembersClient Members { get; }

    public TypesClient Types { get; }

    public TemplatesClient Templates { get; }

    public TagsClient Tags { get; }

    public PropertiesClient Properties { get; }

    public SearchClient Search { get; }

    public ListsClient Lists { get; }
}
