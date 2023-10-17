using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeDiscriminatedUnions;

internal static class EquatableArray
{
    public static EquatableArray<T> ToEquatableArray<T>(this IEnumerable<T> enumerable)
        where T : IEquatable<T>
    {
        return new EquatableArray<T>(enumerable.ToArray());
    }
}

internal readonly struct EquatableArray<T> : IEquatable<EquatableArray<T>>, IEnumerable<T>, IReadOnlyList<T>
    where T : IEquatable<T>
{
    private readonly T[] _array;

    public EquatableArray(T[] array)
    {
        _array = array;
    }

    public T this[int index] => _array[index];

    public int Length => _array.Length;

    int IReadOnlyCollection<T>.Count => _array.Length;

    public bool Equals(EquatableArray<T> other)
    {
        return _array.AsSpan().SequenceEqual(other._array.AsSpan());
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_array).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _array.GetEnumerator();
    }

    public Span<T> AsSpan()
    {
        return _array.AsSpan();
    }
}
