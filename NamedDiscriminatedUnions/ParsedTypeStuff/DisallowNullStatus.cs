namespace NamedDiscriminatedUnions.ParsedTypeStuff;

public enum DisallowNullStatus
{
    None,
    ExistsAllowsNull,
    ExistsThrowsIfNull,
}