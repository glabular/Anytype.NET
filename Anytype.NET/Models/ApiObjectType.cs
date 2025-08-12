namespace Anytype.NET.Models;

public class ApiObjectType
{
    /// <summary>
    /// The data model of the object.
    /// </summary>
    public string Object { get; set; }

    /// <summary>
    /// The id of the type (which is unique across spaces).
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The key of the type (can be the same across spaces for known types).
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    public string PluralName { get; set; }

    /// <summary>
    /// The icon of the object, or null if the object has no icon.
    /// </summary>
    public Icon? Icon { get; set; }

    /// <summary>
    /// Whether the type is archived.
    /// </summary>
    public bool Archived { get; set; }

    /// <summary>
    /// The layout of the object.
    /// </summary>
    public string Layout { get; set; }

    // TODO: not sure about this type, it could be a list.
    /// <summary>
    /// The properties linked to the type.
    /// </summary>
    public object Properties { get; set; }
}
