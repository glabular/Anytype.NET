using Anytype.NET.Interfaces;

namespace Anytype.NET.Models.Requests;

/// <summary>
/// Represents the payload to update an existing object in Anytype.
/// </summary>
public sealed class UpdateObjectRequest
{
    /// <summary>
    /// The name (title) of the object.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The icon of the object.
    /// </summary>
    public IIcon? Icon { get; set; }

    /// <summary>
    /// A list of properties to set for the object.
    /// </summary>
    /// <remarks>
    /// ⚠ Experimental: Subject to change in future Anytype API updates. ⚠
    /// </remarks>
    public object[] Properties { get; set; }
}
