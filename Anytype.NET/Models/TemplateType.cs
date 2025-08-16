using Anytype.NET.Interfaces;

namespace Anytype.NET.Models;

public sealed class TemplateType
{
    /// <summary>
    /// Whether the type is archived.
    /// </summary>
    public bool Archived { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    public IIcon? Icon { get; set; }

    /// <summary>
    /// The id of the type.
    /// </summary>
    /// <remarks>Is unique across spaces.</remarks>
    public string Id { get; set; }

    /// <summary>
    /// The key of the type.
    /// </summary>
    /// <remarks>Can be the same across spaces for known types.</remarks>
    public string Key { get; set; }

    /// <summary>
    /// The layout of the object.
    /// </summary>
    public string Layout { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    public string Object { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    public string PluralName { get; set; }

    /// <summary>
    /// The properties linked to the type.
    /// </summary>
    public List<TemplateProperty> Properties { get; set; }    
}