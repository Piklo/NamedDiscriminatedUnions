using System;

namespace NamedDiscriminatedUnions.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class DisallowNullableAttribute : Attribute
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "used by source generator")]
    public DisallowNullableAttribute(bool throwIfNull = true)
    {
    }
}
