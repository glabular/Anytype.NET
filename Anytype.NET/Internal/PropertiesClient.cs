using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class PropertiesClient : ClientBase
{
    public PropertiesClient(string apiKey) : base(apiKey) { }
}
