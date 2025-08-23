using System.Text.Json.Serialization;

namespace Anytype.NET.Models.Responses;

public sealed class GetTemplateResponse
{
    [JsonPropertyName("template")]
    public Template? Template { get; set; }
}
