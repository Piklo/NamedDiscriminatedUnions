using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NamedDiscriminatedUnions.Generator.Miscellaneous;
using NamedDiscriminatedUnions.Generators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NamedDiscriminatedUnions;

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
        var generics = GetGenerics(context);
        var types = GetParsedTypes(context);
        var isRefStruct = ((INamedTypeSymbol)context.TargetSymbol).IsRefLikeType;
        var data = new DiscriminatedUnionData(name, fullNamespace, generics.ToEquatableArray(), types.ToEquatableArray(), isRefStruct);

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

    private static AllowNullableType ParseAllowNullable(IFieldSymbol field, string fullTypeName, bool isValueType, bool isReferenceType)
    {
        var containsQuestionMark = fullTypeName.EndsWith("?");
        var (attributeFound, attributeValue) = GetAllowNullableAttributeData(field);

        if (isValueType && !containsQuestionMark)
        {
            return AllowNullableType.ImplicitNo;
        }
        else if (!isValueType && !containsQuestionMark && !attributeFound)
        {
            return AllowNullableType.ImplicitYes;
        }
        else if (attributeFound)
        {
            if (!attributeValue)
            {
                return AllowNullableType.ExplicitNo;
            }
            else
            {
                return AllowNullableType.ExplicitNoThrowIfNull;
            }
        }
        else if (containsQuestionMark && !attributeFound)
        {
            return AllowNullableType.ExplicitYes;
        }

        throw new Exception("failed to parse whether type allows nullable or not");
    }

    private static (bool attributeFound, bool attributeValue) GetAllowNullableAttributeData(IFieldSymbol field)
    {
        var attributes = field.GetAttributes();
        foreach (var attribute in attributes)
        {
            var attributeFullName = attribute.AttributeClass?.ToString();
            if (attributeFullName != "NamedDiscriminatedUnions.DisallowNullAttribute")
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
}
