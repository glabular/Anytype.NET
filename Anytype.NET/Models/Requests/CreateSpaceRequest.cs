namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the data required to create a new space.
/// </summary>
public class CreateSpaceRequest
{
    public CreateSpaceRequest(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Space name cannot be null, empty, or whitespace.", nameof(name));
        }

        Name = name;
    }

    public string Name { get; }

    public string? Description { get; set; }
}
