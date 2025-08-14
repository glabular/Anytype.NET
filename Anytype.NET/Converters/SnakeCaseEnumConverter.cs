using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anytype.NET.Converters;

/// <summary>
/// A custom JSON converter that maps enum values from snake_case JSON to PascalCase C# enum names, and vice versa.
/// </summary>
/// <typeparam name="T">The enum type this converter handles.</typeparam>
internal sealed class SnakeCaseEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    /// <summary>
    /// Deserializes a snake_case string from JSON into a PascalCase C# enum value.
    /// </summary>
    /// <returns>The matching enum value.</returns> 
    /// <exception cref="JsonException">Thrown if the input cannot be converted.</exception>
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Read the raw snake_case string value from JSON
        var snake = reader.GetString() ?? throw new JsonException();

        // Convert snake_case to PascalCase (created_date -> CreatedDate)
        var pascal = string.Concat(snake.Split('_').Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1)));

        // Try to parse the PascalCase string into the enum
        if (Enum.TryParse<T>(pascal, ignoreCase: true, out var result))
        {
            return result;
        }

        // Parsing failed
        throw new JsonException($"Unable to convert '{snake}' to enum {typeof(T)}.");
    }

    /// <summary>
    /// Serializes a C# enum value to its equivalent snake_case string for JSON.
    /// </summary>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // Convert PascalCase enum name to snake_case for serialization
        var snakeCase = string.Concat(
            value.ToString()!.Select((c, i) =>
                i > 0 && char.IsUpper(c) ? "_" + char.ToLowerInvariant(c) : char.ToLowerInvariant(c).ToString()
            )
        );

        writer.WriteStringValue(snakeCase);
    }
}
