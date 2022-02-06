using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Model.Converter
{
    public class InfoToString : JsonConverter<string>
    {
        public override string Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                return jsonDoc.RootElement.GetRawText();
            }
        }

        public override void Write(
            Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}