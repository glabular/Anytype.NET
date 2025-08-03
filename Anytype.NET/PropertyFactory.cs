using Anytype.NET.Models;
using Anytype.NET.Models.Enums;

namespace Anytype.NET;

/// <summary>
/// Factory class for creating valid <see cref="Property"/> instances
/// for use in object creation requests to the Anytype API.
/// </summary>
/// <remarks>
/// The API accepts only one value field per property:
/// either <c>text</c>, <c>checkbox</c>, --TODO?--.
/// These factory methods help ensure the property is correctly formed.
/// </remarks>
public static class PropertyFactory
{
    public static Property Description(string text)
    {
        return new Property { Key = PropertyKey.Description, Text = text };
    }

    public static Property Done(bool value)
    {
        return new Property { Key = PropertyKey.Done, Checkbox = value };
    }
}

