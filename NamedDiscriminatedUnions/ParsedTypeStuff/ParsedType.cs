namespace NamedDiscriminatedUnions.ParsedTypeStuff;

internal readonly record struct ParsedType(string FullTypeName, string FullUserTypeName, string FieldName, bool IsValueType, DisallowNullStatus DisallowNullStatus) : IFieldName, IIsValueType, IDisallowNullStatus, IFullTypeName, IFullUserTypeName;
