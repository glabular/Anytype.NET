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
    /// <param name="apiVersion">The API version to use (optional).</param>
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

    /// <summary>
    /// Gets the API version being used by the client.
    /// </summary>
    public string ApiVersion { get; }

    /// <summary>
    /// Provides methods to interact with Anytype auth endpoints.
    /// </summary>
    public static IAuthApi Auth { get; } = new AuthClient();

    /// <summary>
    /// Provides methods to interact with Anytype lists and their views.
    /// </summary>
    public IListsApi Lists { get; }

    /// <summary>
    /// Provides methods to interact with Anytype members.
    /// </summary>
    public IMembersApi Members { get; }

    /// <summary>
    /// Provides methods to interact with Anytype objects.
    /// </summary>
    public IObjectsApi Objects { get; }

    /// <summary>
    /// Provides methods to interact with Anytype properties.
    /// </summary>
    /// <remarks>⚠ Warning: Properties are experimental and may change in the next update.⚠</remarks>
    public IPropertiesApi Properties { get; }

    /// <summary>
    /// Provides methods to search Anytype entities.
    /// </summary>
    public ISearchApi Search { get; }

    /// <summary>
    /// Provides methods to interact with Anytype spaces.
    /// </summary>
    public ISpacesApi Spaces { get; }

    /// <summary>
    /// Provides methods to interact with Anytype tags.
    /// </summary>
    public ITagsApi Tags { get; }

    /// <summary>
    /// Provides methods to interact with Anytype templates.
    /// </summary>
    public ITemplatesApi Templates { get; }

    /// <summary>
    /// Provides methods to interact with Anytype types.
    /// </summary>
    public ITypesApi Types { get; }
}
