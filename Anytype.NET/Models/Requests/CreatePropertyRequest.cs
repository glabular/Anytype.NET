namespace Anytype.NET.Models.Requests;

public sealed class CreatePropertyRequest
{
    /// <summary>
    /// The format of the property used for filtering.
    /// </summary>
    public required string Format { get; set; }

    /// <summary>
    /// The key of the property.
    /// </summary>
    /// <remarks>Should be snake_case, otherwise will be converted.</remarks>
    public string? Key { get; set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    public required string Name { get; set; }
}
