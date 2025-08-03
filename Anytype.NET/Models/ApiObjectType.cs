namespace Anytype.NET.Models;

public class ApiObjectType
{
    public string Object { get; set; }

    public string Id { get; set; }

    public string Key { get; set; }

    public string Name { get; set; }

    public string PluralName { get; set; }

    public Icon Icon { get; set; }

    public bool Archived { get; set; }

    public string Layout { get; set; }

    // TODO: not sure about this type, it could be a list.
    public object Properties { get; set; }
}
