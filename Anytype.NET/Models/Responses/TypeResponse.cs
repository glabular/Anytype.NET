namespace Anytype.NET.Models.Responses;

public sealed class TypeResponse
{
    /// <summary>
    /// The <see cref="AnyType"/> contained within the response body.
    /// </summary>
    public AnyType? Type { get; set; }
}
