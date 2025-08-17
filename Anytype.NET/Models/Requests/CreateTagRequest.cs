namespace Anytype.NET.Models.Requests;

public sealed class CreateTagRequest
{
    /// <summary>
    /// The name of the tag.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The color of the tag.
    /// </summary>
    public string Color { get; set; }
}
