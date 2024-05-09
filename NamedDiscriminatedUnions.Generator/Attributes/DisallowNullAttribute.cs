using System;

namespace NamedDiscriminatedUnions.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class DisallowNullAttribute : Attribute
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "used by source generator")]
    public DisallowNullAttribute(bool throwIfNull = true)
    {
    }
}
