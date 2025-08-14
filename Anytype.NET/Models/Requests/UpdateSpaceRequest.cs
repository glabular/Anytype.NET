namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the data required to update an existing space.
/// </summary>
/// <remarks>
/// The request body should contain the new name and/or description in JSON format.
/// </remarks>
public sealed class UpdateSpaceRequest
{
    public UpdateSpaceRequest(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Space name cannot be null, empty, or whitespace.", nameof(name));
        }

        Name = name;
    }

    /// <summary>
    /// The name of the space.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description of the space.
    /// </summary>
    public string? Description { get; set; }
}
