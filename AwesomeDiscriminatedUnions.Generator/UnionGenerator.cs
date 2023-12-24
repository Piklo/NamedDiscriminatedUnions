using AwesomeDiscriminatedUnions.Generator.Miscellaneous;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AwesomeDiscriminatedUnions;

internal readonly record struct ParsedType(string FullTypeName, string FieldName, bool IsValueType, bool IsRefType, bool IsOrContainsGeneric);

internal readonly record struct DiscriminatedUnionData(string Name, string FullNamespace, EquatableArray<ParsedType> Types);

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

        context.RegisterSourceOutput(discriminatedUnionData, (productionContext, data) =>
        {
            var fileName = $"{data.Name}.g.cs";
            productionContext.AddSource(fileName, $"// {data.Name}");
        });
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
        var types = GetParsedTypes(context);

        var data = new DiscriminatedUnionData(name, fullNamespace, types.ToEquatableArray());

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
            var name = member.Name;
            var isValueType = type.IsValueType;
            var isRefType = type.IsReferenceType;
            var isOrContainsGeneric = IsOrContainsGeneric(type);

            var parsed = new ParsedType(fullTypeName, name, isValueType, isRefType, isOrContainsGeneric);
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
}
