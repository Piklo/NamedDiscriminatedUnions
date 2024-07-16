using System;

namespace NamedDiscriminatedUnions;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class DiscriminatedUnionAttribute : Attribute
{
}