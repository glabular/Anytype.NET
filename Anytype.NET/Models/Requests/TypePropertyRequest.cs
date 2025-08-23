namespace Anytype.NET.Models.Requests;

public sealed class TypePropertyRequest
{
    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    public required string Format { get; set; }

    /// <summary>
    /// The key of the property.
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    public required string Name { get; set; }
}
