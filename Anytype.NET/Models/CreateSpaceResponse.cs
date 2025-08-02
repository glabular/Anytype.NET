using System.Text.Json.Serialization;

namespace Anytype.NET.Models;

public class CreateSpaceResponse
{
    [JsonPropertyName("space")]
    public Space? Space { get; set; }
}
