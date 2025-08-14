using Anytype.NET.Models;
using Anytype.NET.Models.Requests;
using Anytype.NET.Models.Responses;
using System.Text.Json;

namespace Anytype.NET.Internal;

public sealed class TagsClient :ClientBase
{
    public TagsClient(string apiKey) : base(apiKey) { }
}
