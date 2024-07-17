namespace NamedDiscriminatedUnions.Generators;

internal interface IIsTypeMethodOut : ITagEnumData, ICouldBeNull
{
    AllowNullableType AllowNullableInFromMethods { get; }
}
