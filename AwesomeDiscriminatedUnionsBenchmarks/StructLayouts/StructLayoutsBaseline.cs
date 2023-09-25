using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AwesomeDiscriminatedUnionsBenchmarks.StructLayouts;
public class StructLayoutsBaseline
{
    [Benchmark]
    public Int1Sequential Int1Sequential()
    {
        return new Int1Sequential(int.MaxValue);
    }

    [Benchmark]
    public Int1Explicit Int1Explicit()
    {
        return new Int1Explicit(int.MaxValue);
    }

    [Benchmark]
    public Int1Auto Int1Auto()
    {
        return new Int1Auto(int.MaxValue);
    }

    [Benchmark]
    public Int4Sequential Int4Sequential()
    {
        return new Int4Sequential(0, 1, 2, 3);
    }

    [Benchmark]
    public Int4Explicit Int4Explicit()
    {
        return new Int4Explicit(0, 1, 2, 3);
    }

    [Benchmark]
    public Int4Auto Int4Auto()
    {
        return new Int4Auto(0, 1, 2, 3);
    }

    [Benchmark]
    public Int16Sequential Int16Sequential()
    {
        return new Int16Sequential(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
    }

    [Benchmark]
    public Int16Explicit Int16Explicit()
    {
        return new Int16Explicit(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
    }

    [Benchmark]
    public Int16Auto Int16Auto()
    {
        return new Int16Auto(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int1Sequential Int1SequentialNoOptimization()
    {
        return new Int1Sequential(int.MaxValue);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int1Explicit Int1ExplicitNoOptimization()
    {
        return new Int1Explicit(int.MaxValue);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int1Auto Int1AutoNoOptimization()
    {
        return new Int1Auto(int.MaxValue);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int4Sequential Int4SequentialNoOptimization()
    {
        return new Int4Sequential(0, 1, 2, 3);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int4Explicit Int4ExplicitNoOptimization()
    {
        return new Int4Explicit(0, 1, 2, 3);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int4Auto Int4AutoNoOptimization()
    {
        return new Int4Auto(0, 1, 2, 3);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int16Sequential Int16SequentialNoOptimization()
    {
        return new Int16Sequential(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int16Explicit Int16ExplicitNoOptimization()
    {
        return new Int16Explicit(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Int16Auto Int16AutoNoOptimization()
    {
        return new Int16Auto(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
    }
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct Int1Sequential
{
    private readonly int _value1;

    public Int1Sequential(int value1)
    {
        _value1 = value1;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct Int1Explicit
{
    [FieldOffset(0)]
    private readonly int _value1;

    public Int1Explicit(int value1)
    {
        _value1 = value1;
    }
}

[StructLayout(LayoutKind.Auto)]
public readonly struct Int1Auto
{
    private readonly int _value1;

    public Int1Auto(int value1)
    {
        _value1 = value1;
    }
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct Int4Sequential
{
    private readonly int _value1;
    private readonly int _value2;
    private readonly int _value3;
    private readonly int _value4;

    public Int4Sequential(int value1, int value2, int value3, int value4)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct Int4Explicit
{
    [FieldOffset(0)]
    private readonly int _value1;
    [FieldOffset(4)]
    private readonly int _value2;
    [FieldOffset(8)]
    private readonly int _value3;
    [FieldOffset(12)]
    private readonly int _value4;

    public Int4Explicit(int value1, int value2, int value3, int value4)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
    }
}

[StructLayout(LayoutKind.Auto)]
public readonly struct Int4Auto
{
    private readonly int _value1;
    private readonly int _value2;
    private readonly int _value3;
    private readonly int _value4;

    public Int4Auto(int value1, int value2, int value3, int value4)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
    }
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct Int16Sequential
{
    private readonly int _value1;
    private readonly int _value2;
    private readonly int _value3;
    private readonly int _value4;
    private readonly int _value5;
    private readonly int _value6;
    private readonly int _value7;
    private readonly int _value8;
    private readonly int _value9;
    private readonly int _value10;
    private readonly int _value11;
    private readonly int _value12;
    private readonly int _value13;
    private readonly int _value14;
    private readonly int _value15;
    private readonly int _value16;

    public Int16Sequential(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12, int value13, int value14, int value15, int value16)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
        _value5 = value5;
        _value6 = value6;
        _value7 = value7;
        _value8 = value8;
        _value9 = value9;
        _value10 = value10;
        _value11 = value11;
        _value12 = value12;
        _value13 = value13;
        _value14 = value14;
        _value15 = value15;
        _value16 = value16;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct Int16Explicit
{
    [FieldOffset(0)]
    private readonly int _value1;
    [FieldOffset(4)]
    private readonly int _value2;
    [FieldOffset(8)]
    private readonly int _value3;
    [FieldOffset(12)]
    private readonly int _value4;
    [FieldOffset(16)]
    private readonly int _value5;
    [FieldOffset(20)]
    private readonly int _value6;
    [FieldOffset(24)]
    private readonly int _value7;
    [FieldOffset(28)]
    private readonly int _value8;
    [FieldOffset(32)]
    private readonly int _value9;
    [FieldOffset(36)]
    private readonly int _value10;
    [FieldOffset(40)]
    private readonly int _value11;
    [FieldOffset(44)]
    private readonly int _value12;
    [FieldOffset(48)]
    private readonly int _value13;
    [FieldOffset(52)]
    private readonly int _value14;
    [FieldOffset(56)]
    private readonly int _value15;
    [FieldOffset(60)]
    private readonly int _value16;

    public Int16Explicit(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12, int value13, int value14, int value15, int value16)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
        _value5 = value5;
        _value6 = value6;
        _value7 = value7;
        _value8 = value8;
        _value9 = value9;
        _value10 = value10;
        _value11 = value11;
        _value12 = value12;
        _value13 = value13;
        _value14 = value14;
        _value15 = value15;
        _value16 = value16;
    }
}

[StructLayout(LayoutKind.Auto)]
public readonly struct Int16Auto
{
    private readonly int _value1;
    private readonly int _value2;
    private readonly int _value3;
    private readonly int _value4;
    private readonly int _value5;
    private readonly int _value6;
    private readonly int _value7;
    private readonly int _value8;
    private readonly int _value9;
    private readonly int _value10;
    private readonly int _value11;
    private readonly int _value12;
    private readonly int _value13;
    private readonly int _value14;
    private readonly int _value15;
    private readonly int _value16;

    public Int16Auto(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10, int value11, int value12, int value13, int value14, int value15, int value16)
    {
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
        _value5 = value5;
        _value6 = value6;
        _value7 = value7;
        _value8 = value8;
        _value9 = value9;
        _value10 = value10;
        _value11 = value11;
        _value12 = value12;
        _value13 = value13;
        _value14 = value14;
        _value15 = value15;
        _value16 = value16;
    }
}