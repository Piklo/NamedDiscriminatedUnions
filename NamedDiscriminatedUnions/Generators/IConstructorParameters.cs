namespace NamedDiscriminatedUnions.Generators;

internal interface IConstructorParameters : ICouldBeNull, IConstructorBody
{
}

internal interface IConstructorBody
{
    string FieldName { get; }
}