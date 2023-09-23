using System;

namespace AwesomeDiscriminatedUnions;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DiscriminatedUnionAttribute : Attribute
{
    public const EqualsType DefaultEqualsType = EqualsType.Strict;
    public const GetHashCodeType DefaultGetHashCodeType = GetHashCodeType.Strict;
#pragma warning disable IDE0052 // Remove unread private members
    private readonly EqualsType _equalsType;
    private readonly GetHashCodeType _getHashCodeType;
#pragma warning restore IDE0052 // Remove unread private members

    public DiscriminatedUnionAttribute(EqualsType equalsType = DefaultEqualsType, GetHashCodeType getHashCodeType = DefaultGetHashCodeType)
    {
        _equalsType = equalsType;
        _getHashCodeType = getHashCodeType;
    }
}
