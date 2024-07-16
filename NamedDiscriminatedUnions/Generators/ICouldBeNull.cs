namespace NamedDiscriminatedUnions.Generators;

internal interface ICouldBeNull
{
    string FullTypeName { get; }
    bool IsValueType { get; }
}
