using System;

namespace NamedDiscriminatedUnions.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DiscriminatedUnionAttribute : Attribute
{
}