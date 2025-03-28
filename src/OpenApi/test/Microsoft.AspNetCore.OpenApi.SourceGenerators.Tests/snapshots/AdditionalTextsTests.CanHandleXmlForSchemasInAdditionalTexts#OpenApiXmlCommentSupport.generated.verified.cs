﻿//HintName: OpenApiXmlCommentSupport.generated.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
// Suppress warnings about obsolete types and members
// in generated code
#pragma warning disable CS0612, CS0618

namespace System.Runtime.CompilerServices
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    file sealed class InterceptsLocationAttribute : System.Attribute
    {
        public InterceptsLocationAttribute(int version, string data)
        {
        }
    }
}

namespace Microsoft.AspNetCore.OpenApi.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.OpenApi;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Models.References;
    using Microsoft.OpenApi.Any;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file record XmlComment(
        string? Summary,
        string? Description,
        string? Remarks,
        string? Returns,
        string? Value,
        bool Deprecated,
        List<string>? Examples,
        List<XmlParameterComment>? Parameters,
        List<XmlResponseComment>? Responses);

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file record XmlParameterComment(string? Name, string? Description, string? Example, bool Deprecated);

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file record XmlResponseComment(string Code, string? Description, string? Example);

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file static class XmlCommentCache
    {
        private static Dictionary<string, XmlComment>? _cache;
        public static Dictionary<string, XmlComment> Cache => _cache ??= GenerateCacheEntries();

        private static Dictionary<string, XmlComment> GenerateCacheEntries()
        {
            var cache = new Dictionary<string, XmlComment>();
            cache.Add(@"T:ClassLibrary.Todo", new XmlComment(@"This is a todo item.", null, null, null, null, false, null, null, null));
            cache.Add(@"T:ClassLibrary.Project", new XmlComment(@"The project that contains Todo items.", null, null, null, null, false, null, null, null));
            cache.Add(@"M:ClassLibrary.Project.#ctor(System.String,System.String)", new XmlComment(@"The project that contains Todo items.", null, null, null, null, false, null, null, null));
            cache.Add(@"T:ClassLibrary.ProjectBoard.BoardItem", new XmlComment(@"An item on the board.", null, null, null, null, false, null, null, null));
            cache.Add(@"P:ClassLibrary.ProjectBoard.BoardItem.Name", new XmlComment(@"The identifier of the board item. Defaults to ""name"".", null, null, null, null, false, null, null, null));
            cache.Add(@"T:ClassLibrary.ProjectRecord", new XmlComment(@"The project that contains Todo items.", null, null, null, null, false, null, [new XmlParameterComment(@"Name", @"The name of the project.", null, false), new XmlParameterComment(@"Description", @"The description of the project.", null, false)], null));
            cache.Add(@"M:ClassLibrary.ProjectRecord.#ctor(System.String,System.String)", new XmlComment(@"The project that contains Todo items.", null, null, null, null, false, null, [new XmlParameterComment(@"Name", @"The name of the project.", null, false), new XmlParameterComment(@"Description", @"The description of the project.", null, false)], null));
            cache.Add(@"P:ClassLibrary.ProjectRecord.Name", new XmlComment(@"The name of the project.", null, null, null, null, false, null, null, null));
            cache.Add(@"P:ClassLibrary.ProjectRecord.Description", new XmlComment(@"The description of the project.", null, null, null, null, false, null, null, null));
            cache.Add(@"P:ClassLibrary.TodoWithDescription.Id", new XmlComment(@"The identifier of the todo.", null, null, null, null, false, null, null, null));
            cache.Add(@"P:ClassLibrary.TodoWithDescription.Name", new XmlComment(null, null, null, null, @"The name of the todo.", false, null, null, null));
            cache.Add(@"P:ClassLibrary.TodoWithDescription.Description", new XmlComment(@"A description of the todo.", null, null, null, @"Another description of the todo.", false, null, null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.BooleanType", new XmlComment(null, null, null, null, null, false, [@"true"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.IntegerType", new XmlComment(null, null, null, null, null, false, [@"42"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.LongType", new XmlComment(null, null, null, null, null, false, [@"1234567890123456789"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.DoubleType", new XmlComment(null, null, null, null, null, false, [@"3.14"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.FloatType", new XmlComment(null, null, null, null, null, false, [@"3.14"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.DateTimeType", new XmlComment(null, null, null, null, null, false, [@"2022-01-01T00:00:00Z"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.DateOnlyType", new XmlComment(null, null, null, null, null, false, [@"2022-01-01"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.StringType", new XmlComment(null, null, null, null, null, false, [@"Hello, World!"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.GuidType", new XmlComment(null, null, null, null, null, false, [@"2d8f1eac-b5c6-4e29-8c62-4d9d75ef3d3d"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.TimeOnlyType", new XmlComment(null, null, null, null, null, false, [@"12:30:45"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.TimeSpanType", new XmlComment(null, null, null, null, null, false, [@"P3DT4H5M"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.ByteType", new XmlComment(null, null, null, null, null, false, [@"255"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.DecimalType", new XmlComment(null, null, null, null, null, false, [@"3.14159265359"], null, null));
            cache.Add(@"P:ClassLibrary.TypeWithExamples.UriType", new XmlComment(null, null, null, null, null, false, [@"https://example.com"], null, null));
            cache.Add(@"P:ClassLibrary.Holder`1.Value", new XmlComment(@"The value to hold.", null, null, null, null, false, null, null, null));
            cache.Add(@"M:ClassLibrary.Endpoints.ExternalMethod(System.String)", new XmlComment(@"An external method.", null, null, null, null, false, null, [new XmlParameterComment(@"name", @"The name of the tester. Defaults to ""Tester"".", null, false)], null));
            cache.Add(@"M:ClassLibrary.Endpoints.CreateHolder``1(``0)", new XmlComment(@"Creates a holder for the specified value.", null, null, @"A holder for the specified value.", null, false, [@"{ value: 42 }"], [new XmlParameterComment(@"value", @"The value to hold.", null, false)], null));


            return cache;
        }
    }

    file static class DocumentationCommentIdHelper
    {
        /// <summary>
        /// Generates a documentation comment ID for a type.
        /// Example: T:Namespace.Outer+Inner`1 becomes T:Namespace.Outer.Inner`1
        /// </summary>
        public static string CreateDocumentationId(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return "T:" + GetTypeDocId(type, includeGenericArguments: false, omitGenericArity: false);
        }

        /// <summary>
        /// Generates a documentation comment ID for a property.
        /// Example: P:Namespace.ContainingType.PropertyName or for an indexer P:Namespace.ContainingType.Item(System.Int32)
        /// </summary>
        public static string CreateDocumentationId(this PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            var sb = new StringBuilder();
            sb.Append("P:");

            if (property.DeclaringType != null)
            {
                sb.Append(GetTypeDocId(property.DeclaringType, includeGenericArguments: false, omitGenericArity: false));
            }

            sb.Append('.');
            sb.Append(property.Name);

            // For indexers, include the parameter list.
            var indexParams = property.GetIndexParameters();
            if (indexParams.Length > 0)
            {
                sb.Append('(');
                for (int i = 0; i < indexParams.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(',');
                    }

                    sb.Append(GetTypeDocId(indexParams[i].ParameterType, includeGenericArguments: true, omitGenericArity: false));
                }
                sb.Append(')');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates a documentation comment ID for a method (or constructor).
        /// For example:
        ///   M:Namespace.ContainingType.MethodName(ParamType1,ParamType2)~ReturnType
        ///   M:Namespace.ContainingType.#ctor(ParamType)
        /// </summary>
        public static string CreateDocumentationId(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            var sb = new StringBuilder();
            sb.Append("M:");

            // Append the fully qualified name of the declaring type.
            if (method.DeclaringType != null)
            {
                sb.Append(GetTypeDocId(method.DeclaringType, includeGenericArguments: false, omitGenericArity: false));
            }

            sb.Append('.');

            // Append the method name, handling constructors specially.
            if (method.IsConstructor)
            {
                sb.Append(method.IsStatic ? "#cctor" : "#ctor");
            }
            else
            {
                sb.Append(method.Name);
                if (method.IsGenericMethod)
                {
                    sb.Append("``");
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}", method.GetGenericArguments().Length);
                }
            }

            // Append the parameter list, if any.
            var parameters = method.GetParameters();
            if (parameters.Length > 0)
            {
                sb.Append('(');
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(',');
                    }

                    // Omit the generic arity for the parameter type.
                    sb.Append(GetTypeDocId(parameters[i].ParameterType, includeGenericArguments: true, omitGenericArity: true));
                }
                sb.Append(')');
            }

            // Append the return type after a '~' (if the method returns a value).
            if (method.ReturnType != typeof(void))
            {
                sb.Append('~');
                // Omit the generic arity for the return type.
                sb.Append(GetTypeDocId(method.ReturnType, includeGenericArguments: true, omitGenericArity: true));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates a documentation ID string for a type.
        /// This method handles nested types (replacing '+' with '.'),
        /// generic types, arrays, pointers, by-ref types, and generic parameters.
        /// The <paramref name="includeGenericArguments"/> flag controls whether
        /// constructed generic type arguments are emitted, while <paramref name="omitGenericArity"/>
        /// controls whether the generic arity marker (e.g. "`1") is appended.
        /// </summary>
        private static string GetTypeDocId(Type type, bool includeGenericArguments, bool omitGenericArity)
        {
            if (type.IsGenericParameter)
            {
                // Use `` for method-level generic parameters and ` for type-level.
                if (type.DeclaringMethod != null)
                {
                    return "``" + type.GenericParameterPosition;
                }
                else if (type.DeclaringType != null)
                {
                    return "`" + type.GenericParameterPosition;
                }
                else
                {
                    return type.Name;
                }
            }

            if (type.IsArray && type.GetElementType() is { } elementType)
            {
                int rank = type.GetArrayRank();
                var sb = new StringBuilder(GetTypeDocId(elementType, includeGenericArguments, omitGenericArity));
                if (rank > 1)
                {
                    sb.Append('[');
                    sb.Append(',', rank - 1);
                    sb.Append(']');
                }
                else
                {
                    sb.Append("[]");
                }
            }

            if (type.IsGenericType)
            {
                Type genericDef = type.GetGenericTypeDefinition();
                string fullName = genericDef.FullName ?? genericDef.Name;

                var sb = new StringBuilder(fullName.Length);

                // Replace '+' with '.' for nested types
                for (var i = 0; i < fullName.Length; i++)
                {
                    char c = fullName[i];
                    if (c == '+')
                    {
                        sb.Append('.');
                    }
                    else if (c == '`')
                    {
                        break;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }

                if (!omitGenericArity)
                {
                    int arity = genericDef.GetGenericArguments().Length;
                    sb.Append('`');
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}", arity);
                }

                if (includeGenericArguments && !type.IsGenericTypeDefinition)
                {
                    var typeArgs = type.GetGenericArguments();
                    sb.Append('{');

                    for (int i = 0; i < typeArgs.Length; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(',');
                        }

                        sb.Append(GetTypeDocId(typeArgs[i], includeGenericArguments, omitGenericArity));
                    }

                    sb.Append('}');
                }

                return sb.ToString();
            }

            // For non-generic types, use FullName (if available) and replace nested type separators.
            return (type.FullName ?? type.Name).Replace('+', '.');
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file class XmlCommentOperationTransformer : IOpenApiOperationTransformer
    {
        public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken cancellationToken)
        {
            var methodInfo = context.Description.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor
                ? controllerActionDescriptor.MethodInfo
                : context.Description.ActionDescriptor.EndpointMetadata.OfType<MethodInfo>().SingleOrDefault();

            if (methodInfo is null)
            {
                return Task.CompletedTask;
            }
            if (XmlCommentCache.Cache.TryGetValue(methodInfo.CreateDocumentationId(), out var methodComment))
            {
                if (methodComment.Summary is { } summary)
                {
                    operation.Summary = summary;
                }
                if (methodComment.Description is { } description)
                {
                    operation.Description = description;
                }
                if (methodComment.Remarks is { } remarks)
                {
                    operation.Description = remarks;
                }
                if (methodComment.Parameters is { Count: > 0})
                {
                    foreach (var parameterComment in methodComment.Parameters)
                    {
                        var parameterInfo = methodInfo.GetParameters().SingleOrDefault(info => info.Name == parameterComment.Name);
                        var operationParameter = operation.Parameters?.SingleOrDefault(parameter => parameter.Name == parameterComment.Name);
                        if (operationParameter is not null)
                        {
                            var targetOperationParameter = operationParameter is OpenApiParameterReference reference
                                ? reference.Target
                                : (OpenApiParameter)operationParameter;
                            targetOperationParameter.Description = parameterComment.Description;
                            if (parameterComment.Example is { } jsonString)
                            {
                                targetOperationParameter.Example = jsonString.Parse();
                            }
                            targetOperationParameter.Deprecated = parameterComment.Deprecated;
                        }
                        else
                        {
                            var requestBody = operation.RequestBody;
                            if (requestBody is not null)
                            {
                                requestBody.Description = parameterComment.Description;
                                if (parameterComment.Example is { } jsonString)
                                {
                                    foreach (var mediaType in requestBody.Content.Values)
                                    {
                                        mediaType.Example = jsonString.Parse();
                                    }
                                }
                            }
                        }
                    }
                }
                if (methodComment.Responses is { Count: > 0} && operation.Responses is { Count: > 0 })
                {
                    foreach (var response in operation.Responses)
                    {
                        var responseComment = methodComment.Responses.SingleOrDefault(xmlResponse => xmlResponse.Code == response.Key);
                        if (responseComment is not null)
                        {
                            response.Value.Description = responseComment.Description;
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file class XmlCommentSchemaTransformer : IOpenApiSchemaTransformer
    {
        public Task TransformAsync(OpenApiSchema schema, OpenApiSchemaTransformerContext context, CancellationToken cancellationToken)
        {
            if (context.JsonPropertyInfo is { AttributeProvider: PropertyInfo propertyInfo })
            {
                if (XmlCommentCache.Cache.TryGetValue(propertyInfo.CreateDocumentationId(), out var propertyComment))
                {
                    schema.Description = propertyComment.Value ?? propertyComment.Returns ?? propertyComment.Summary;
                    if (propertyComment.Examples?.FirstOrDefault() is { } jsonString)
                    {
                        schema.Example = jsonString.Parse();
                    }
                }
            }
            if (XmlCommentCache.Cache.TryGetValue(context.JsonTypeInfo.Type.CreateDocumentationId(), out var typeComment))
            {
                schema.Description = typeComment.Summary;
                if (typeComment.Examples?.FirstOrDefault() is { } jsonString)
                {
                    schema.Example = jsonString.Parse();
                }
            }
            return Task.CompletedTask;
        }
    }

    file static class JsonNodeExtensions
    {
        public static JsonNode? Parse(this string? json)
        {
            if (json is null)
            {
                return null;
            }

            try
            {
                return JsonNode.Parse(json);
            }
            catch (JsonException)
            {
                try
                {
                    // If parsing fails, try wrapping in quotes to make it a valid JSON string
                    return JsonNode.Parse($"\"{json.Replace("\"", "\\\"")}\"");
                }
                catch (JsonException)
                {
                    return null;
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    file static class GeneratedServiceCollectionExtensions
    {
        [InterceptsLocation]
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            return services.AddOpenApi("v1", options =>
            {
                options.AddSchemaTransformer(new XmlCommentSchemaTransformer());
                options.AddOperationTransformer(new XmlCommentOperationTransformer());
            });
        }

    }
}