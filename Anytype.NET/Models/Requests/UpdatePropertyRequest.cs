namespace Anytype.NET.Models.Requests;

public sealed class UpdatePropertyRequest
{
    /// <summary>
    /// The key to set for the property.
    /// </summary>
    /// <remarks>Should be snake_case.</remarks>
    public string? Key { get; set; }

    /// <summary>
    /// The name to set for the property.
    /// </summary>
    public required string Name { get; set; }
}
