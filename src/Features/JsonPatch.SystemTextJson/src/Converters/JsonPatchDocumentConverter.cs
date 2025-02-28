// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson.Operations;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;

namespace Microsoft.AspNetCore.JsonPatch.SystemTextJson.Converters;

public class JsonPatchDocumentConverter : JsonConverter<JsonPatchDocument>
{
    internal static DefaultJsonTypeInfoResolver DefaultContractResolver { get; } = new();

    public override JsonPatchDocument Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(JsonPatchDocument))
        {
            throw new ArgumentException(Resources.FormatParameterMustMatchType(nameof(typeToConvert), "JsonPatchDocument"), nameof(typeToConvert));
        }

        try
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            var operations = new List<Operation>();

            JsonNode node = JsonArray.Parse(ref reader, new JsonNodeOptions { PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive });
            JsonArray operationsArray = node.AsArray();
            foreach (var item in operationsArray)
            {
                operations.Add(item.Deserialize<Operation>(options));
            }

            // container target: the JsonPatchDocument.
            var container = new JsonPatchDocument(operations, DefaultContractResolver);

            return container;
        }
        catch (Exception ex)
        {
            throw new JsonException(Resources.InvalidJsonPatchDocument, ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, JsonPatchDocument value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var operation in value.Operations)
        {
            JsonSerializer.Serialize(writer, operation, options);
        }

        writer.WriteEndArray();
    }

    public override bool CanConvert(Type typeToConvert)
    {
        if (typeToConvert == typeof(JsonPatchDocument) || typeToConvert == typeof(JsonPatchDocument<>))
            var result = base.CanConvert(typeToConvert);
        return result;
    }
}
