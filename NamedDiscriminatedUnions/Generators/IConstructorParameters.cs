namespace NamedDiscriminatedUnions.Generators;

internal interface IConstructorParameters : ICouldBeNull
{
    string FieldName { get; }
}
