namespace Anytype.NET.Models.Requests;

public sealed class CreateTypeRequest
{
    /// <summary>
    /// The icon of the type (nullable).
    /// </summary>
    public Icon? Icon { get; set; }

    /// <summary>
    /// The key of the type.
    /// </summary>
    /// <remarks>Should always be snake_case, otherwise it will be converted to snake_case.</remarks>
    public string Key { get; set; }

    /// <summary>
    /// The layout of the type. Possible values: basic, profile, action, note.
    /// </summary>
    public string Layout { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The plural name of the type.
    /// </summary>
    public string PluralName { get; set; }

    /// <summary>
    /// The list of properties linked to the type.
    /// ⚠ Experimental and subject to change.
    /// </summary>
    public List<CreateTypePropertyRequest> Properties { get; set; }
}
