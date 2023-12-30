using System;

namespace AwesomeDiscriminatedUnions.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class DisallowNullableAttribute : Attribute
{
    public DisallowNullableAttribute(bool throwIfNull = true)
    {
    }
}
