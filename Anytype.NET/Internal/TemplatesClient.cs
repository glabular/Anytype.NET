using Anytype.NET.Models.Responses;
using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class TemplatesClient : ClientBase
{
    public TemplatesClient(string apiKey) : base(apiKey) { }
}
