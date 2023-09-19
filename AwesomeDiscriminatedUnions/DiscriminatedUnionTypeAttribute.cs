using System;

namespace AwesomeDiscriminatedUnions;

[AttributeUsage(AttributeTargets.Struct, AllowMultiple = true)]
public sealed class DiscriminatedUnionTypeAttribute : Attribute
{
#pragma warning disable IDE0052 // Remove unread private members
    private readonly Type type;
    private readonly string customName;
    private readonly int priority;
    private readonly bool shouldBox;
#pragma warning restore IDE0052 // Remove unread private members
    public DiscriminatedUnionTypeAttribute(Type type, string customName = "", int priority = 0, bool shouldBox = false)
    {
        this.type = type;
        this.customName = customName;
        this.priority = priority;
        this.shouldBox = shouldBox;
    }
}
