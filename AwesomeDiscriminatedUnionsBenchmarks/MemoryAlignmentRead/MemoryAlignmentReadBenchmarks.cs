using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace AwesomeDiscriminatedUnionsBenchmarks.MemoryAlignmentRead;

[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[HideColumns("obj", "array")]
public class MemoryAlignmentReadBenchmarks
{
    private const int HowManyToConstruct = 1000;
    private const int value = 123;
    public IEnumerable<IntBaseline> IntBaselineArg()
    {
        yield return new IntBaseline(value);
    }
    public IEnumerable<Int0> Int0Arg()
    {
        yield return new Int0(value);
    }
    public IEnumerable<Int1> Int1Arg()
    {
        yield return new Int1(value);
    }
    public IEnumerable<Int2> Int2Arg()
    {
        yield return new Int2(value);
    }
    public IEnumerable<Int3> Int3Arg()
    {
        yield return new Int3(value);
    }
    public IEnumerable<Int4> Int4Arg()
    {
        yield return new Int4(value);
    }
    public IEnumerable<IntBaseline[]> IntBaselineManyArg()
    {
        yield return IntBaselineMany();
    }
    public IEnumerable<Int0[]> Int0ManyArg()
    {
        yield return Int0Many();
    }
    public IEnumerable<Int1[]> Int1ManyArg()
    {
        yield return Int1Many();
    }
    public IEnumerable<Int2[]> Int2ManyArg()
    {
        yield return Int2Many();
    }
    public IEnumerable<Int3[]> Int3ManyArg()
    {
        yield return Int3Many();
    }
    public IEnumerable<Int4[]> Int4ManyArg()
    {
        yield return Int4Many();
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("construct")]
    public IntBaseline IntBaseline()
    {
        return new IntBaseline(value);
    }
    [Benchmark]
    [BenchmarkCategory("construct")]
    public Int0 Int0()
    {
        return new Int0(value);
    }
    [Benchmark]
    [BenchmarkCategory("construct")]
    public Int1 Int1()
    {
        return new Int1(value);
    }
    [Benchmark]
    [BenchmarkCategory("construct")]
    public Int2 Int2()
    {
        return new Int2(value);
    }
    [Benchmark]
    [BenchmarkCategory("construct")]
    public Int3 Int3()
    {
        return new Int3(value);
    }
    [Benchmark]
    [BenchmarkCategory("construct")]
    public Int4 Int4()
    {
        return new Int4(value);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("constructMany")]
    public IntBaseline[] IntBaselineMany()
    {
        var res = new IntBaseline[HowManyToConstruct];
        for (var i = 0; i < HowManyToConstruct; i++)
        {
            res[i] = new IntBaseline(i);
        }
        return res;
    }
    [Benchmark]
    [BenchmarkCategory("constructMany")]
    public Int0[] Int0Many()
    {
        var res = new Int0[HowManyToConstruct];
        for (var i = 0; i < HowManyToConstruct; i++)
        {
            res[i] = new Int0(i);
        }
        return res;
    }
    [Benchmark]
    [BenchmarkCategory("constructMany")]
    public Int1[] Int1Many()
    {
        var res = new Int1[HowManyToConstruct];
        for (var i = 0; i < HowManyToConstruct; i++)
        {
            res[i] = new Int1(i);
        }
        return res;
    }
    [Benchmark]
    [BenchmarkCategory("constructMany")]
    public Int2[] Int2Many()
    {
        var res = new Int2[HowManyToConstruct];
        for (var i = 0; i < HowManyToConstruct; i++)
        {
            res[i] = new Int2(i);
        }
        return res;
    }
    [Benchmark]
    [BenchmarkCategory("constructMany")]
    public Int3[] Int3Many()
    {
        var res = new Int3[HowManyToConstruct];
        for (var i = 0; i < HowManyToConstruct; i++)
        {
            res[i] = new Int3(i);
        }
        return res;
    }
    [Benchmark]
    [BenchmarkCategory("constructMany")]
    public Int4[] Int4Many()
    {
        var res = new Int4[HowManyToConstruct];
        for (var i = 0; i < HowManyToConstruct; i++)
        {
            res[i] = new Int4(i);
        }
        return res;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("read")]
    [ArgumentsSource(nameof(IntBaselineArg))]
    public int ReadIntBaseline(IntBaseline obj)
    {
        return obj.value;
    }
    [Benchmark]
    [BenchmarkCategory("read")]
    [ArgumentsSource(nameof(Int0Arg))]
    public int ReadInt0(Int0 obj)
    {
        return obj.value;
    }
    [Benchmark]
    [BenchmarkCategory("read")]
    [ArgumentsSource(nameof(Int1Arg))]
    public int ReadInt1(Int1 obj)
    {
        return obj.value;
    }
    [Benchmark]
    [BenchmarkCategory("read")]
    [ArgumentsSource(nameof(Int2Arg))]
    public int ReadInt2(Int2 obj)
    {
        return obj.value;
    }
    [Benchmark]
    [BenchmarkCategory("read")]
    [ArgumentsSource(nameof(Int3Arg))]
    public int ReadInt3(Int3 obj)
    {
        return obj.value;
    }
    [Benchmark]
    [BenchmarkCategory("read")]
    [ArgumentsSource(nameof(Int4Arg))]
    public int ReadInt4(Int4 obj)
    {
        return obj.value;
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("readMany")]
    [ArgumentsSource(nameof(IntBaselineManyArg))]
    public int ReadManyIntBaseline(IntBaseline[] array)
    {
        var sum = 0;
        foreach (var item in array)
        {
            sum += item.value;
        }
        return sum;
    }
    [Benchmark]
    [BenchmarkCategory("readMany")]
    [ArgumentsSource(nameof(Int0ManyArg))]
    public int ReadManyInt0(Int0[] array)
    {
        var sum = 0;
        foreach (var item in array)
        {
            sum += item.value;
        }
        return sum;
    }
    [Benchmark]
    [BenchmarkCategory("readMany")]
    [ArgumentsSource(nameof(Int1ManyArg))]
    public int ReadManyInt1(Int1[] array)
    {
        var sum = 0;
        foreach (var item in array)
        {
            sum += item.value;
        }
        return sum;
    }
    [Benchmark]
    [BenchmarkCategory("readMany")]
    [ArgumentsSource(nameof(Int2ManyArg))]
    public int ReadManyInt2(Int2[] array)
    {
        var sum = 0;
        foreach (var item in array)
        {
            sum += item.value;
        }
        return sum;
    }
    [Benchmark]
    [BenchmarkCategory("readMany")]
    [ArgumentsSource(nameof(Int3ManyArg))]
    public int ReadManyInt3(Int3[] array)
    {
        var sum = 0;
        foreach (var item in array)
        {
            sum += item.value;
        }
        return sum;
    }
    [Benchmark]
    [BenchmarkCategory("readMany")]
    [ArgumentsSource(nameof(Int4ManyArg))]
    public int ReadManyInt4(Int4[] array)
    {
        var sum = 0;
        foreach (var item in array)
        {
            sum += item.value;
        }
        return sum;
    }
}

public readonly struct IntBaseline
{
    public readonly int value;
    public readonly byte _tag;

    public IntBaseline(int value)
    {
        this.value = value;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct Int0
{
    [FieldOffset(0)]
    public readonly int value;
    [FieldOffset(7)]
    public readonly byte _tag;

    public Int0(int value)
    {
        this.value = value;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct Int1
{
    [FieldOffset(1)]
    public readonly int value;
    [FieldOffset(7)]
    public readonly byte _tag;

    public Int1(int value)
    {
        this.value = value;
    }
}
[StructLayout(LayoutKind.Explicit)]
public readonly struct Int2
{
    [FieldOffset(2)]
    public readonly int value;
    [FieldOffset(7)]
    public readonly byte _tag;

    public Int2(int value)
    {
        this.value = value;
    }
}
[StructLayout(LayoutKind.Explicit)]
public readonly struct Int3
{
    [FieldOffset(3)]
    public readonly int value;
    [FieldOffset(7)]
    public readonly byte _tag;

    public Int3(int value)
    {
        this.value = value;
    }
}
[StructLayout(LayoutKind.Explicit)]
public readonly struct Int4
{
    [FieldOffset(4)]
    public readonly int value;
    [FieldOffset(0)]
    public readonly byte _tag;

    public Int4(int value)
    {
        this.value = value;
    }
}