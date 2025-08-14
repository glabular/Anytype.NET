using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

/// <summary>
/// Provides methods to interact with Anytype types.
/// </summary>
public sealed class TypesClient : ClientBase
{
    public TypesClient(string apiKey) : base(apiKey) { }
}
