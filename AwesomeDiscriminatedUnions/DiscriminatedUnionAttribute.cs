using System;

namespace AwesomeDiscriminatedUnions;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DiscriminatedUnionAttribute : Attribute
{
#pragma warning disable IDE0052 // Remove unread private members
    private readonly EqualsType _equalsType;
    private readonly GetHashCodeType _getHashCodeType;
#pragma warning restore IDE0052 // Remove unread private members

    public DiscriminatedUnionAttribute(EqualsType equalsType, GetHashCodeType getHashCodeType = GetHashCodeType.Strict)
    {
        _equalsType = equalsType;
        _getHashCodeType = getHashCodeType;
    }
}
