using System;

namespace AwesomeDiscriminatedUnions;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DiscriminatedUnionAttribute : Attribute
{
#pragma warning disable IDE0052 // Remove unread private members
    private readonly DiscriminatedUnionGetHashCodeType _getHashCodeType;
#pragma warning restore IDE0052 // Remove unread private members

    public DiscriminatedUnionAttribute(DiscriminatedUnionGetHashCodeType getHashCodeType = DiscriminatedUnionGetHashCodeType.Strict)
    {
        _getHashCodeType = getHashCodeType;
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