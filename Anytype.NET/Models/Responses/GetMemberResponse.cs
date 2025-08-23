using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class GetMemberResponse
{
    [JsonPropertyName("member")]
    public AnyMember? Member { get; set; }
}
