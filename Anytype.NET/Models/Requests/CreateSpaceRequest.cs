namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the data required to create a new space.
/// </summary>
public sealed class CreateSpaceRequest
{
    public required string Name { get; set;  }

    public string? Description { get; set; }
}
