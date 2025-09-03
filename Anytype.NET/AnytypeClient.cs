using Anytype.NET.Constants;
using Anytype.NET.Interfaces;
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
    public AnytypeClient(string apiKey, string? apiVersion = null)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        ApiVersion = apiVersion ?? AnytypeApiVersions.GetLatest();
        Spaces = new SpacesClient(_apiKey, ApiVersion);
        Objects = new ObjectsClient(_apiKey, ApiVersion);
        Members = new MembersClient(_apiKey, ApiVersion);
        Types = new TypesClient(_apiKey, ApiVersion);
        Templates = new TemplatesClient(_apiKey, ApiVersion);
        Tags = new TagsClient(_apiKey, ApiVersion);
        Properties = new PropertiesClient(_apiKey, ApiVersion);
        Search = new SearchClient(_apiKey, ApiVersion);
        Lists = new ListsClient(_apiKey, ApiVersion);
    }

    public string ApiVersion { get; }
    
    public ISpacesApi Spaces { get; }

    public IObjectsApi Objects { get; }

    public IMembersApi Members { get; }

    public ITypesApi Types { get; }

    public ITemplatesApi Templates { get; }

    public ITagsApi Tags { get; }

    public IPropertiesApi Properties { get; }

    public ISearchApi Search { get; }

    public IListsApi Lists { get; }

    public static IAuthApi Auth { get; } = new AuthClient();    
}
