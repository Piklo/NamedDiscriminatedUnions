using AwesomeDiscriminatedUnions.Generator.Miscellaneous;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
namespace AwesomeDiscriminatedUnions;

internal readonly record struct ParsedType(string FullTypeName, string FieldName, bool IsValueType, bool IsReferenceType, bool IsGeneric, bool ContainsGeneric, ParsedType.AllowNullableType AllowNullableInFromMethods)
{
    public enum AllowNullableType
    {
        ImplicitNo, // value type without '?'
        ImplicitYes, // not value type without '?' and without DisallowNullableAttribute
        ExplicitNo, // DisallowNullableAttribute(false)
        ExplicitNoThrowIfNull, // DisallowNullableAttribute(true)
        ExplicitYes, // type with '?' without DisallowNullableAttribute
    }
}

internal readonly record struct DiscriminatedUnionData(string Name, string FullNamespace, EquatableArray<string> Generics, EquatableArray<ParsedType> Types);

[Generator]
internal class UnionGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var discriminatedUnionData =
            context.SyntaxProvider.ForAttributeWithMetadataName(
                "AwesomeDiscriminatedUnions.Attributes.DiscriminatedUnionAttribute",
                IsRightNode,
                ParseDiscriminatedUnionData);

        context.RegisterSourceOutput(discriminatedUnionData, GenerateUnion);
    }

    private static bool IsRightNode(SyntaxNode node, CancellationToken cancellationToken)
    {
        var result = node is StructDeclarationSyntax;
        return result;
    }

    private static DiscriminatedUnionData ParseDiscriminatedUnionData(GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken)
    {
        var name = context.TargetSymbol.Name;
        var fullNamespace = GetFullNamespace(context.TargetSymbol);
        var generics = GetGenerics(context);
        var types = GetParsedTypes(context);
        var data = new DiscriminatedUnionData(name, fullNamespace, generics.ToEquatableArray(), types.ToEquatableArray());

        return data;
    }

    private static string GetFullNamespace(ISymbol symbol)
    {
        var namespaceBuilder = new StringBuilder();
        var currentNamespace = symbol.ContainingNamespace;
        while (currentNamespace is not null && !string.IsNullOrWhiteSpace(currentNamespace.Name))
        {
            if (namespaceBuilder.Length != 0)
            {
                namespaceBuilder.Insert(0, '.');
            }
            namespaceBuilder.Insert(0, currentNamespace.Name);
            currentNamespace = currentNamespace.ContainingNamespace;
        }

        return namespaceBuilder.ToString();
    }

    private static string[] GetGenerics(GeneratorAttributeSyntaxContext context)
    {
        var genericsList = new List<string>();

        var generics = ((INamedTypeSymbol)context.TargetSymbol).TypeArguments;
        foreach (var type in generics)
        {
            var typeStr = type.ToString();
            genericsList.Add(typeStr);
        }

        return [.. genericsList];
    }

    private static ParsedType[] GetParsedTypes(GeneratorAttributeSyntaxContext context)
    {
        var list = new List<ParsedType>();
        var typeSymbol = (INamedTypeSymbol)context.TargetSymbol;
        var members = typeSymbol.GetMembers();

        foreach (var member in members)
        {
            if (member is not IFieldSymbol field)
            {
                continue;
            }

            var type = field.Type;
            var fullTypeName = type.ToString();
            var fieldName = member.Name;
            var isValueType = type.IsValueType;
            var isReferenceType = type.IsReferenceType;
            var isGeneric = IsGeneric(type);
            var containsGeneric = ContainsGeneric(type);
            var allowNullable = ParseAllowNullable(field, fullTypeName, isValueType, isReferenceType);

            var parsed = new ParsedType(fullTypeName, fieldName, isValueType, isReferenceType, isGeneric, containsGeneric, allowNullable);
            list.Add(parsed);
        }

        return [.. list];
    }

    private static bool IsGeneric(ITypeSymbol type)
    {
        return type.Kind == SymbolKind.TypeParameter;
    }

    private static bool ContainsGeneric(ITypeSymbol type)
    {
        if (type is not INamedTypeSymbol named)
        {
            return false;
        }

        var arguments = named.TypeArguments;
        foreach (var argument in arguments)
        {
            if (IsOrContainsGeneric(argument))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsOrContainsGeneric(ITypeSymbol type)
    {
        return IsGeneric(type) || ContainsGeneric(type);
    }

    private static ParsedType.AllowNullableType ParseAllowNullable(IFieldSymbol field, string fullTypeName, bool isValueType, bool isReferenceType)
    {
        var containsQuestionMark = fullTypeName.EndsWith("?");
        var (attributeFound, attributeValue) = GetAllowNullableAttributeData(field);

        if (isValueType && !containsQuestionMark)
        {
            return ParsedType.AllowNullableType.ImplicitNo;
        }
        else if (!isValueType && !containsQuestionMark && !attributeFound)
        {
            return ParsedType.AllowNullableType.ImplicitYes;
        }
        else if (attributeFound)
        {
            if (!attributeValue)
            {
                return ParsedType.AllowNullableType.ExplicitNo;
            }
            else
            {
                return ParsedType.AllowNullableType.ExplicitNoThrowIfNull;
            }
        }
        else if (containsQuestionMark && !attributeFound)
        {
            return ParsedType.AllowNullableType.ExplicitYes;
        }

        throw new Exception("failed to parse whether type allows nullable or not");
    }

    private static (bool attributeFound, bool attributeValue) GetAllowNullableAttributeData(IFieldSymbol field)
    {
        var attributes = field.GetAttributes();
        foreach (var attribute in attributes)
        {
            var attributeFullName = attribute.AttributeClass?.ToString();
            if (attributeFullName != "AwesomeDiscriminatedUnions.Attributes.DisallowNullableAttribute")
            {
                continue;
            }

            if (attribute.ConstructorArguments[0].Value is bool explicitValue)
            {
                return (true, explicitValue);
            }
            else
            {
                throw new Exception("non bool value, bool expected");
            }
        }

        return (false, default);
    }

    private static void GenerateUnion(SourceProductionContext productionContext, DiscriminatedUnionData data)
    {
        if (data.Types.Array.Length == 0)
        {
            return;
        }

        using var baseWriter = new StringWriter();
        using var writer = new IndentedTextWriter(baseWriter, new string(' ', 4));
        writer.WriteLine("// <auto-generated/>");
        writer.WriteEmptyLine();
        writer.WriteLine("#nullable enable");
        writer.WriteEmptyLine();

        if (!string.IsNullOrWhiteSpace(data.FullNamespace))
        {
            writer.WriteLine($"namespace {data.FullNamespace};");
        }

        writer.WriteEmptyLine();

        AppendDeclaration(writer, data);
        writer.WriteLine("{");
        writer.WriteIndentedBlock((writer) =>
        {
            AppendTags(writer, data);
            AppendFields(writer, data);
            AppendConstructor(writer, data);
            AppendIsTypeMethods(writer, data);
            AppendFromTypeMethods(writer, data);
        });
        writer.WriteLine("}");

        var code = baseWriter.ToString();

        var fileName = $"{data.Name}.g.cs";
        productionContext.AddSource(fileName, code);
    }

    private static void AppendDeclaration(IndentedTextWriter writer, DiscriminatedUnionData data)
    {
        writer.WriteLine("[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Auto)]");
        var type = GetFullTypeNameWithGenerics(data);
        writer.WriteLine($"partial struct {type}");
    }

    private static string GetFullTypeNameWithGenerics(DiscriminatedUnionData data)
    {
        var generics = data.Generics.Array.Length > 0 ? $"<{string.Join(", ", data.Generics.Array)}>" : string.Empty;
        return $"{data.Name}{generics}";
    }

    private static void AppendTags(IndentedTextWriter writer, DiscriminatedUnionData data)
    {
        writer.WriteLine("public enum Tag : byte");
        writer.WriteLine("{");
        writer.WriteIndentedBlock((writer) =>
        {
            for (var i = 0; i < data.Types.Array.Length; i++)
            {
                var type = data.Types.Array[i];
                var tagName = GetTagName(type);
                writer.WriteLine($"{tagName} = {i + 1},");
            }
        });
        writer.WriteLine("}");
        writer.WriteLine();
    }

    private static string GetTagName(ParsedType type)
    {
        var first = char.ToUpper(type.FieldName[0]);
        var tagName = first + type.FieldName.Substring(1);

        return tagName;
    }

    private static void AppendFields(IndentedTextWriter writer, DiscriminatedUnionData data)
    {
        writer.WriteLine("private readonly Tag tag;");
        writer.WriteLine();
    }

    private static void AppendConstructor(IndentedTextWriter writer, DiscriminatedUnionData data)
    {
        writer.Write($"private {data.Name}(Tag tag, ");
        for (var i = 0; i < data.Types.Array.Length; i++)
        {
            var type = data.Types.Array[i];
            var questionMark = CouldBeNull(type) && !type.FullTypeName.EndsWith("?") ? "?" : string.Empty;
            writer.Write($"{type.FullTypeName}{questionMark} {type.FieldName}");
            if (i + 1 < data.Types.Array.Length)
            {
                writer.Write(", ");
            }
        }

        writer.WriteLine(")");
        writer.WriteLine("{");
        writer.WriteIndentedBlock((writer) =>
        {
            writer.WriteLine("this.tag = tag;");
            foreach (var type in data.Types.Array)
            {
                writer.WriteLine($"this.{type.FieldName} = {type.FieldName};");
            }
        });
        writer.WriteLine("}");
        writer.WriteLine();
    }

    private static void AppendIsTypeMethods(IndentedTextWriter writer, DiscriminatedUnionData data)
    {
        foreach (var type in data.Types.Array)
        {
            AppendIsTypeMethodWithoutOut(writer, type);
            AppendIsTypeMethodWithOut(writer, type);
        }
    }

    private static void AppendIsTypeMethodWithoutOut(IndentedTextWriter writer, ParsedType type)
    {
        var tagName = GetTagName(type);
        writer.WriteLine($"public readonly bool Is{tagName}()");
        writer.WriteLine('{');
        writer.WriteIndentedBlock((writer) =>
        {
            writer.WriteLine($"return tag == Tag.{tagName};");
        });
        writer.WriteLine('}');
        writer.WriteLine();
    }

    private static void AppendIsTypeMethodWithOut(IndentedTextWriter writer, ParsedType type)
    {
        var tagName = GetTagName(type);
        var couldBeNull = CouldBeNull(type);
        var canUseNotNullWhenAttribute = couldBeNull && type.AllowNullableInFromMethods == ParsedType.AllowNullableType.ExplicitNoThrowIfNull;
        var notNullWhenAttribute = canUseNotNullWhenAttribute ? "[System.Diagnostics.CodeAnalysis.NotNullWhen(true)] " : string.Empty;
        var questionMark = couldBeNull && !type.FullTypeName.EndsWith("?") ? "?" : string.Empty;
        writer.WriteLine($"public readonly bool Is{tagName}({notNullWhenAttribute}out {type.FullTypeName}{questionMark} value)");
        writer.WriteLine('{');
        writer.WriteIndentedBlock((writer) =>
        {
            writer.WriteLine($"if (tag == Tag.{tagName})");
            writer.WriteLine('{');
            writer.WriteIndentedBlock(writer =>
            {
                if (canUseNotNullWhenAttribute)
                {
                    writer.WriteLine($"value = this.{type.FieldName}!;"); /// we can use null forgiving because of <see cref="ParsedType.AllowNullableType.ExplicitNoThrowIfNull"/>
                }
                else
                {
                    writer.WriteLine($"value = this.{type.FieldName};");
                }

                writer.WriteLine("return true;");
            });
            writer.WriteLine('}');
            writer.WriteLine();
            writer.WriteLine("value = default;");
            writer.WriteLine("return false;");
        });
        writer.WriteLine('}');
        writer.WriteLine();
    }

    private static bool CouldBeNull(ParsedType type)
    {
        return type.FullTypeName.EndsWith("?") || !type.IsValueType;
    }


    private static void AppendFromTypeMethods(IndentedTextWriter writer, DiscriminatedUnionData data)
    {
        for (var i = 0; i < data.Types.Array.Length; i++)
        {
            var type = data.Types.Array[i];
            var tag = GetTagName(type);
            var fullTypeName = GetFullTypeNameWithGenerics(data);

            writer.WriteLine($"public static {fullTypeName} From{tag}({type.FullTypeName} value)");
            writer.WriteLine('{');
            writer.WriteIndentedBlock(writer =>
            {
                if (type.AllowNullableInFromMethods == ParsedType.AllowNullableType.ExplicitNoThrowIfNull)
                {
                    writer.WriteLine("if (value is null)");
                    writer.WriteLine('{');
                    writer.WriteIndentedBlock(writer =>
                    {
                        writer.WriteLine("throw new System.ArgumentNullException(nameof(value));");
                    });
                    writer.WriteLine('}');
                    writer.WriteLine();
                }

                writer.Write($"return new {fullTypeName}(Tag.{tag}, ");
                for (var j = 0; j < data.Types.Array.Length; j++)
                {
                    var type2 = data.Types.Array[j];

                    if (j == i)
                    {
                        writer.Write("value");
                    }
                    else
                    {
                        writer.Write("default");
                    }

                    if (j + 1 < data.Types.Array.Length)
                    {
                        writer.Write(", ");
                    }
                }

                writer.WriteLine(");");
            });
            writer.WriteLine('}');
            writer.WriteLine();
        }
    }
}
