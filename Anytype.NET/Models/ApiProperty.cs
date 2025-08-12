namespace Anytype.NET.Models;

// TODO: Think on better class naming.
public class ApiProperty
{
    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    public string Format { get; set; } // TODO: Create enum for all possible values.

    /// <summary>
    /// The id of the property.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The key of the property.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The data model of the object.
    /// </summary>
    public string Object { get; set; }
}
