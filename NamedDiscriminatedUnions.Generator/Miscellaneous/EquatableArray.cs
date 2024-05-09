using System;
using System.Collections.Generic;
using System.Linq;

namespace NamedDiscriminatedUnions.Generator.Miscellaneous;

internal static class EquatableArray
{
    public static EquatableArray<T> ToEquatableArray<T>(this IEnumerable<T> enumerable)
        where T : IEquatable<T>
    {
        return new EquatableArray<T>(enumerable.ToArray());
    }
}

internal readonly struct EquatableArray<T>(T[] array) : IEquatable<EquatableArray<T>>
    where T : IEquatable<T>
{
    public T[] Array { get; } = array;

    public bool Equals(EquatableArray<T> other)
    {
        return Array.AsSpan().SequenceEqual(other.Array.AsSpan());
    }
}
