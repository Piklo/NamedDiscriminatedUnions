using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NamedDiscriminatedUnions.Generator.Miscellaneous;
using NamedDiscriminatedUnions.Generators;
using NamedDiscriminatedUnions.ParsedTypeStuff;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NamedDiscriminatedUnions;

internal readonly record struct GenericType(string FullNamespace, string TypeName, bool IsValueType, bool IsReferenceType, bool IsGeneric);

[Generator]
internal class UnionGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var discriminatedUnionData =
            context.SyntaxProvider.ForAttributeWithMetadataName(
                "NamedDiscriminatedUnions.DiscriminatedUnionAttribute",
                IsRightNode,
                ParseDiscriminatedUnionData);

        context.RegisterSourceOutput(discriminatedUnionData, BaseGenerator.GenerateUnion);
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
        var generics = GetGenerics((INamedTypeSymbol)context.TargetSymbol);
        var types = GetParsedTypes(context);
        var isRefStruct = ((INamedTypeSymbol)context.TargetSymbol).IsRefLikeType;
        var data = new DiscriminatedUnionData(name, fullNamespace, generics.ToEquatableArray(), types.ToEquatableArray(), isRefStruct);

        return data;
    }

    private static string GetFullNamespace(ISymbol symbol)
    {
        var currentNamespace = symbol.ContainingNamespace;
        if (currentNamespace is null)
        {
            return "";
        }

        var namespaceBuilder = new StringBuilder();
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

    private static string[] GetGenerics(INamedTypeSymbol? symbol)
    {
        if (symbol is null)
        {
            return [];
        }

        var genericsList = new List<string>();

        var generics = symbol.TypeArguments;
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

            var fullUserTypeName = type.ToString();
            var fullTypeName = fullUserTypeName;

            if (!type.IsValueType && !fullTypeName.EndsWith("?"))
            {
                fullTypeName += '?';
            }

            var fieldName = member.Name;
            var isValueType = type.IsValueType;
            var disallowNullStatus = ParseDisallowNullAttribute(field);

            var parsed = new ParsedType(fullTypeName, fullUserTypeName, fieldName, isValueType, disallowNullStatus);
            list.Add(parsed);
        }

        return [.. list];
    }

    private static DisallowNullStatus ParseDisallowNullAttribute(IFieldSymbol field)
    {
        var (attributeFound, throwIfNull) = GetAllowNullableAttributeData(field);

        if (!attributeFound)
        {
            return DisallowNullStatus.None;
        }

        if (!throwIfNull)
        {
            return DisallowNullStatus.ExistsAllowsNull;
        }

        return DisallowNullStatus.ExistsThrowsIfNull;
    }

    private static (bool attributeFound, bool throwIfNull) GetAllowNullableAttributeData(IFieldSymbol field)
    {
        var attributes = field.GetAttributes();
        foreach (var attribute in attributes)
        {
            var attributeFullName = attribute.AttributeClass?.ToString();
            if (attributeFullName != "NamedDiscriminatedUnions.DisallowNullAttribute")
            {
                continue;
            }

            if (attribute.ConstructorArguments[0].Value is bool throwIfNull)
            {
                return (true, throwIfNull);
            }
            else
            {
                throw new Exception("non bool value, bool expected");
            }
        }

        return (false, default);
    }
}
