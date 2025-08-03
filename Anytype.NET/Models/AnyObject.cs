namespace Anytype.NET.Models;

/// <summary>
/// Represents an object that was successfully created through the API.
/// </summary>
public class AnyObject
{
    public string Object { get; set; }

    public string Id { get; set; }

    public string Name { get; set; }

    public Icon Icon { get; set; }

    public bool Archived { get; set; }

    public string SpaceId { get; set; }

    public string Snippet { get; set; }

    public string Layout { get; set; }

    public ApiObjectType Type { get; set; }

    public List<Property> Properties { get; set; }

    public string Markdown { get; set; }
}
