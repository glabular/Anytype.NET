using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype properties.
/// </summary>
/// <remarks>⚠ Warning: Properties are experimental and may change in the next update. ⚠</remarks>
public sealed class PropertiesClient : ClientBase
{
    public PropertiesClient(string apiKey) : base(apiKey) { }
}
