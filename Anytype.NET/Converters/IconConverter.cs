using Anytype.NET.Interfaces;
using Anytype.NET.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anytype.NET.Converters;

internal sealed class IconConverter : JsonConverter<IIcon>
{
    public override IIcon? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("format", out var formatProp))
        {
            throw new JsonException("Icon format property is missing.");
        }

        var format = formatProp.GetString();

        return format switch
        {
            "emoji" => JsonSerializer.Deserialize<EmojiIcon>(root.GetRawText(), options),
            "file" => JsonSerializer.Deserialize<FileIcon>(root.GetRawText(), options),
            "icon" => JsonSerializer.Deserialize<NamedIcon>(root.GetRawText(), options),
            _ => throw new JsonException($"Unknown icon format: {format}")
        };
    }

    public override void Write(Utf8JsonWriter writer, IIcon value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}
