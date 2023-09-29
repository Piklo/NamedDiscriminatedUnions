using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AwesomeDiscriminatedUnionsBenchmarks.MemoryAlignmentAndOverlapping;

[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class MemoryAlignmentOverlappingBenchmarks
{
    private const string _string = "hello world";
    private const int _int = int.MaxValue;
    private const long _long = long.MaxValue;

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("string")]
    public Baseline BaselineString()
    {
        return new Baseline(_string);
    }
    [Benchmark]
    [BenchmarkCategory("string")]
    public ExplicitNonOverlappingMisaligned ExplicitNonOverlappingMisalignedString()
    {
        return new ExplicitNonOverlappingMisaligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("string")]
    public ExplicitNonOverlappingAligned ExplicitNonOverlappingAlignedString()
    {
        return new ExplicitNonOverlappingAligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("string")]
    public ExplicitOverlappingMisaligned ExplicitOverlappingMisalignedString()
    {
        return new ExplicitOverlappingMisaligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("string")]
    public ExplicitOverlappingAligned ExplicitOverlappingAlignedString()
    {
        return new ExplicitOverlappingAligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("string")]
    public ExplicitOverlappingAlignedOptimized ExplicitOverlappingAlignedOptimizedString()
    {
        return new ExplicitOverlappingAlignedOptimized(_string);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("int")]
    public Baseline BaselineInt()
    {
        return new Baseline(_int);
    }
    [Benchmark]
    [BenchmarkCategory("int")]
    public ExplicitNonOverlappingMisaligned ExplicitNonOverlappingMisalignedInt()
    {
        return new ExplicitNonOverlappingMisaligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("int")]
    public ExplicitNonOverlappingAligned ExplicitNonOverlappingAlignedInt()
    {
        return new ExplicitNonOverlappingAligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("int")]
    public ExplicitOverlappingMisaligned ExplicitOverlappingMisalignedInt()
    {
        return new ExplicitOverlappingMisaligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("int")]
    public ExplicitOverlappingAligned ExplicitOverlappingAlignedInt()
    {
        return new ExplicitOverlappingAligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("int")]
    public ExplicitOverlappingAlignedOptimized ExplicitOverlappingAlignedOptimizedInt()
    {
        return new ExplicitOverlappingAlignedOptimized(_int);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("long")]
    public Baseline BaselineLong()
    {
        return new Baseline(_long);
    }
    [Benchmark]
    [BenchmarkCategory("long")]
    public ExplicitNonOverlappingMisaligned ExplicitNonOverlappingMisalignedLong()
    {
        return new ExplicitNonOverlappingMisaligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("long")]
    public ExplicitNonOverlappingAligned ExplicitNonOverlappingAlignedLong()
    {
        return new ExplicitNonOverlappingAligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("long")]
    public ExplicitOverlappingMisaligned ExplicitOverlappingMisalignedLong()
    {
        return new ExplicitOverlappingMisaligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("long")]
    public ExplicitOverlappingAligned ExplicitOverlappingAlignedLong()
    {
        return new ExplicitOverlappingAligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("long")]
    public ExplicitOverlappingAlignedOptimized ExplicitOverlappingAlignedOptimizedLong()
    {
        return new ExplicitOverlappingAlignedOptimized(_long);
    }
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("stringNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Baseline BaselineStringNoOptimization()
    {
        return new Baseline(_string);
    }
    [Benchmark]
    [BenchmarkCategory("stringNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitNonOverlappingMisaligned ExplicitNonOverlappingMisalignedStringNoOptimization()
    {
        return new ExplicitNonOverlappingMisaligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("stringNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitNonOverlappingAligned ExplicitNonOverlappingAlignedStringNoOptimization()
    {
        return new ExplicitNonOverlappingAligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("stringNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingMisaligned ExplicitOverlappingMisalignedStringNoOptimization()
    {
        return new ExplicitOverlappingMisaligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("stringNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingAligned ExplicitOverlappingAlignedStringNoOptimization()
    {
        return new ExplicitOverlappingAligned(_string);
    }
    [Benchmark]
    [BenchmarkCategory("stringNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingAlignedOptimized ExplicitOverlappingAlignedOptimizedStringNoOptimization()
    {
        return new ExplicitOverlappingAlignedOptimized(_string);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("intNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Baseline BaselineIntNoOptimization()
    {
        return new Baseline(_int);
    }
    [Benchmark]
    [BenchmarkCategory("intNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitNonOverlappingMisaligned ExplicitNonOverlappingMisalignedIntNoOptimization()
    {
        return new ExplicitNonOverlappingMisaligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("intNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitNonOverlappingAligned ExplicitNonOverlappingAlignedIntNoOptimization()
    {
        return new ExplicitNonOverlappingAligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("intNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingMisaligned ExplicitOverlappingMisalignedIntNoOptimization()
    {
        return new ExplicitOverlappingMisaligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("intNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingAligned ExplicitOverlappingAlignedIntNoOptimization()
    {
        return new ExplicitOverlappingAligned(_int);
    }
    [Benchmark]
    [BenchmarkCategory("intNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingAlignedOptimized ExplicitOverlappingAlignedOptimizedIntNoOptimization()
    {
        return new ExplicitOverlappingAlignedOptimized(_int);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("longNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public Baseline BaselineLongNoOptimization()
    {
        return new Baseline(_long);
    }
    [Benchmark]
    [BenchmarkCategory("longNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitNonOverlappingMisaligned ExplicitNonOverlappingMisalignedLongNoOptimization()
    {
        return new ExplicitNonOverlappingMisaligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("longNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitNonOverlappingAligned ExplicitNonOverlappingAlignedLongNoOptimization()
    {
        return new ExplicitNonOverlappingAligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("longNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingMisaligned ExplicitOverlappingMisalignedLongNoOptimization()
    {
        return new ExplicitOverlappingMisaligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("longNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingAligned ExplicitOverlappingAlignedLongNoOptimization()
    {
        return new ExplicitOverlappingAligned(_long);
    }
    [Benchmark]
    [BenchmarkCategory("longNoOptimization")]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public ExplicitOverlappingAlignedOptimized ExplicitOverlappingAlignedOptimizedLongNoOptimization()
    {
        return new ExplicitOverlappingAlignedOptimized(_long);
    }
}


public readonly struct Baseline
{
    private readonly string? _string;
    private readonly byte _tag;
    private readonly int _int;
    private readonly long _long;

    public Baseline(string value)
    {
        _string = value;
        _tag = 1;
    }

    public Baseline(int value)
    {
        _int = value;
        _tag = 2;
    }

    public Baseline(long value)
    {
        _long = value;
        _tag = 3;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct ExplicitNonOverlappingMisaligned
{
    [FieldOffset(0)]
    private readonly string? _string;
    [FieldOffset(8)]
    private readonly byte _tag;
    [FieldOffset(9)]
    private readonly int _int;
    [FieldOffset(13)]
    private readonly long _long;

    public ExplicitNonOverlappingMisaligned(string value)
    {
        _string = value;
        _tag = 1;
    }

    public ExplicitNonOverlappingMisaligned(int value)
    {
        _int = value;
        _tag = 2;
    }

    public ExplicitNonOverlappingMisaligned(long value)
    {
        _long = value;
        _tag = 3;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct ExplicitNonOverlappingAligned
{
    [FieldOffset(0)]
    private readonly string? _string;
    [FieldOffset(8)]
    private readonly byte _tag;
    [FieldOffset(12)]
    private readonly int _int;
    [FieldOffset(16)]
    private readonly long _long;

    public ExplicitNonOverlappingAligned(string value)
    {
        _string = value;
        _tag = 1;
    }

    public ExplicitNonOverlappingAligned(int value)
    {
        _int = value;
        _tag = 2;
    }

    public ExplicitNonOverlappingAligned(long value)
    {
        _long = value;
        _tag = 3;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct ExplicitOverlappingMisaligned
{
    [FieldOffset(0)]
    private readonly string? _string;
    [FieldOffset(8)]
    private readonly byte _tag;
    [FieldOffset(9)]
    private readonly int _int;
    [FieldOffset(9)]
    private readonly long _long;

    public ExplicitOverlappingMisaligned(string value)
    {
        _string = value;
        _tag = 1;
    }

    public ExplicitOverlappingMisaligned(int value)
    {
        _int = value;
        _tag = 2;
    }

    public ExplicitOverlappingMisaligned(long value)
    {
        _long = value;
        _tag = 3;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct ExplicitOverlappingAligned
{
    [FieldOffset(0)]
    private readonly string? _string;
    [FieldOffset(16)]
    private readonly byte _tag;
    [FieldOffset(8)]
    private readonly int _int;
    [FieldOffset(8)]
    private readonly long _long;

    public ExplicitOverlappingAligned(string value)
    {
        _string = value;
        _tag = 1;
    }

    public ExplicitOverlappingAligned(int value)
    {
        _int = value;
        _tag = 2;
    }

    public ExplicitOverlappingAligned(long value)
    {
        _long = value;
        _tag = 3;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct ExplicitOverlappingAlignedOptimized
{
    [FieldOffset(0)]
    private readonly string? _string;
    [FieldOffset(8)]
    private readonly byte _tag;
    [FieldOffset(16)]
    private readonly int _int;
    [FieldOffset(16)]
    private readonly long _long;

    public ExplicitOverlappingAlignedOptimized(string value)
    {
        _string = value;
        _tag = 1;
    }

    public ExplicitOverlappingAlignedOptimized(int value)
    {
        _int = value;
        _tag = 2;
    }

    public ExplicitOverlappingAlignedOptimized(long value)
    {
        _long = value;
        _tag = 3;
    }
}