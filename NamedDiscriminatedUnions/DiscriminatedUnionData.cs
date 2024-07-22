using NamedDiscriminatedUnions.Generator.Miscellaneous;
using NamedDiscriminatedUnions.ParsedTypeStuff;

namespace NamedDiscriminatedUnions;

internal readonly record struct DiscriminatedUnionData(string TypeName, string FullNamespace, EquatableArray<string> Generics, EquatableArray<ParsedType> Types, bool IsRefStruct);