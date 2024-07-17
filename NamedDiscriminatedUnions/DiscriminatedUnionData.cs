using NamedDiscriminatedUnions.Generator.Miscellaneous;

namespace NamedDiscriminatedUnions;

internal readonly record struct DiscriminatedUnionData(string Name, string FullNamespace, EquatableArray<string> Generics, EquatableArray<ParsedType> Types, bool IsRefStruct);
