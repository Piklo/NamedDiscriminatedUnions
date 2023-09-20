using System;

namespace AwesomeDiscriminatedUnions;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DiscriminatedUnionGetHashCodeAttribute : Attribute
{
    private readonly DiscriminatedUnionGetHashCodeType _type;

    public DiscriminatedUnionGetHashCodeAttribute(DiscriminatedUnionGetHashCodeType type)
    {
        _type = type;
    }
}


public enum DiscriminatedUnionGetHashCodeType
{
    /// <summary>
    /// Do not generate GetHashCode method
    /// </summary>
    None,
    /// <summary>
    /// Generate GetHashCode method based on the item value and the tag value
    /// </summary>
    Strict,
    /// <summary>
    /// Generate GetHashCode method based on only the item value
    /// </summary>
    Weak,
}