using Microsoft.CodeAnalysis;
using NamedDiscriminatedUnions.Generator.Miscellaneous;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NamedDiscriminatedUnions;

internal static class UnionParser
{
    internal static DiscriminatedUnionData ParseDiscriminatedUnionData(GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken)
    {
        var name = context.TargetSymbol.Name;
        var fullNamespace = GetFullNamespace(context.TargetSymbol);
        var generics = GetGenerics((INamedTypeSymbol)context.TargetSymbol);
        var types = FieldsParser.GetParsedTypes(context);
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
}
