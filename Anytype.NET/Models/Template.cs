using Anytype.NET.Interfaces;

namespace Anytype.NET.Models;

public sealed class Template
{
    /// <summary>
    /// Whether the object is archived.
    /// </summary>
    public bool Archived { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    public IIcon? Icon { get; set; }

    /// <summary>
    /// The id of the object.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The layout of the object.
    /// </summary>
    public string Layout { get; set; }

    /// <summary>
    /// The markdown body of the object.
    /// </summary>
    public string Markdown { get; set; }

    /// <summary>
    /// The name of the object.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    public string Object { get; set; }

    /// <summary>
    /// The properties of the object.
    /// </summary>
    public List<TemplateProperty> Properties { get; set; }

    /// <summary>
    /// The snippet of the object.
    /// </summary>
    /// <remarks>Especially important for notes as they don't have a name.</remarks>
    public string Snippet { get; set; }

    /// <summary>
    /// The id of the space the object is in.
    /// </summary>
    public string SpaceId { get; set; }

    /// <summary>
    /// The type of the object, or null if the type has been deleted.
    /// </summary>
    public TemplateType? Type { get; set; }
}
