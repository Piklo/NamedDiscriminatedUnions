namespace NamedDiscriminatedUnions.Generators;

internal interface INotNullAttribute : ICouldBeNull
{
    AllowNullableType AllowNullableInFromMethods { get; }
}