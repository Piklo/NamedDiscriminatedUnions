using Microsoft.CodeAnalysis;
using NamedDiscriminatedUnions.ParsedTypeStuff;
using System;
using System.Collections.Generic;

namespace NamedDiscriminatedUnions;

internal static class FieldsParser
{
    internal static ParsedType[] GetParsedTypes(GeneratorAttributeSyntaxContext context)
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
