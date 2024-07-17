using NamedDiscriminatedUnions.Generators;

namespace NamedDiscriminatedUnions;

internal readonly record struct ParsedType(string FullTypeName, string FieldName, bool IsValueType, bool IsReferenceType, bool IsGeneric, bool ContainsGeneric, AllowNullableType AllowNullableInFromMethods) : IConstructorParameters, ICouldBeNull, ITagEnumData, IIsTypeMethodOut;

public enum AllowNullableType
{
    ImplicitNo, // value type without '?'
    ImplicitYes, // not value type without '?' and without DisallowNullAttribute
    ExplicitNo, // DisallowNullAttribute(false)
    ExplicitNoThrowIfNull, // DisallowNullAttribute(true)
    ExplicitYes, // type with '?' without DisallowNullAttribute
}