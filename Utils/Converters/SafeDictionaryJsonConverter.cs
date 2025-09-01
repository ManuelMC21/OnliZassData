using System.Text.Json;
using System.Text.Json.Serialization;

namespace onlizas.Utils.Converters;

public class SafeDictionaryJsonConverter : JsonConverter<Dictionary<string, string>?>
{
    public override Dictionary<string, string>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var dictionary = new Dictionary<string, string>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return dictionary;
            }

            // Read property name
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = reader.GetString();
            if (string.IsNullOrEmpty(propertyName))
            {
                continue;
            }

            // Read value
            reader.Read();

            string? value = null;

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    value = reader.GetString();
                    break;
                case JsonTokenType.Number:
                    value = reader.GetDecimal().ToString();
                    break;
                case JsonTokenType.True:
                    value = "true";
                    break;
                case JsonTokenType.False:
                    value = "false";
                    break;
                case JsonTokenType.StartArray:
                    // Handle array by converting to comma-separated string
                    var arrayValues = new List<string>();
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        if (reader.TokenType == JsonTokenType.String)
                        {
                            var arrayItem = reader.GetString();
                            if (!string.IsNullOrEmpty(arrayItem))
                            {
                                arrayValues.Add(arrayItem);
                            }
                        }
                        else if (reader.TokenType == JsonTokenType.Number)
                        {
                            arrayValues.Add(reader.GetDecimal().ToString());
                        }
                    }
                    value = string.Join(", ", arrayValues);
                    break;
                case JsonTokenType.StartObject:
                    // Skip complex objects by reading through them
                    int depth = 1;
                    while (reader.Read() && depth > 0)
                    {
                        if (reader.TokenType == JsonTokenType.StartObject)
                            depth++;
                        else if (reader.TokenType == JsonTokenType.EndObject)
                            depth--;
                    }
                    value = "[Object]";
                    break;
                case JsonTokenType.Null:
                    value = null;
                    break;
                default:
                    // Skip unknown token types
                    value = "[Unknown]";
                    break;
            }

            if (value != null)
            {
                dictionary[propertyName] = value;
            }
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, string>? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteStartObject();

        foreach (var kvp in value)
        {
            writer.WritePropertyName(kvp.Key);
            writer.WriteStringValue(kvp.Value);
        }

        writer.WriteEndObject();
    }
}