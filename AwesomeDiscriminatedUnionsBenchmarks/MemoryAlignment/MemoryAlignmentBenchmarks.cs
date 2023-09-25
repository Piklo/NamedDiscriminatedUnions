using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AwesomeDiscriminatedUnionsBenchmarks.MemoryAlignment;
public class MemoryAlignmentBenchmarks
{
    private readonly byte _byteValue = 1;
    private readonly int _intValue1 = 1;
    private readonly int _intValue2 = 2;

    [Benchmark]
    public MemoryAligned1Int MemoryAligned1Int()
    {
        return new MemoryAligned1Int(_byteValue, _intValue1);
    }

    [Benchmark]
    public MemoryMisaligned1Int MemoryMisaligned1Int()
    {
        return new MemoryMisaligned1Int(_byteValue, _intValue1);
    }

    [Benchmark]
    public MemoryAligned2Int MemoryAligned2Int()
    {
        return new MemoryAligned2Int(_byteValue, _intValue1, _intValue2);
    }

    [Benchmark]
    public MemoryMisaligned2Int MemoryMisaligned2Int()
    {
        return new MemoryMisaligned2Int(_byteValue, _intValue1, _intValue2);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public MemoryAligned1Int MemoryAligned1IntNoOptimization()
    {
        return new MemoryAligned1Int(_byteValue, _intValue1);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public MemoryMisaligned1Int MemoryMisaligned1IntNoOptimization()
    {
        return new MemoryMisaligned1Int(_byteValue, _intValue1);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public MemoryAligned2Int MemoryAligned2IntNoOptimization()
    {
        return new MemoryAligned2Int(_byteValue, _intValue1, _intValue2);
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public MemoryMisaligned2Int MemoryMisaligned2IntNoOptimization()
    {
        return new MemoryMisaligned2Int(_byteValue, _intValue1, _intValue2);
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryAligned1Int
{
    [FieldOffset(0)]
    private readonly byte _byteValue;

    [FieldOffset(4)]
    private readonly int _intValue1;

    public MemoryAligned1Int(byte byteValue, int intValue1)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryMisaligned1Int
{
    [FieldOffset(0)]
    private readonly byte _byteValue;

    [FieldOffset(1)]
    private readonly int _intValue1;

    public MemoryMisaligned1Int(byte byteValue, int intValue1)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryAligned2Int
{
    [FieldOffset(0)]
    private readonly byte _byteValue;

    [FieldOffset(4)]
    private readonly int _intValue1;

    [FieldOffset(8)]
    private readonly int _intValue2;

    public MemoryAligned2Int(byte byteValue, int intValue1, int intValue2)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
        _intValue2 = intValue2;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryMisaligned2Int
{
    [FieldOffset(0)]
    private readonly byte _byteValue;

    [FieldOffset(1)]
    private readonly int _intValue1;

    [FieldOffset(5)]
    private readonly int _intValue2;

    public MemoryMisaligned2Int(byte byteValue, int intValue1, int intValue2)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
        _intValue2 = intValue2;
    }
}

/*
unsafe
{
    var basecase1Int = new Basecase1Int(1, 1);
    byte* addr = (byte*) &basecase1Int;
    Console.WriteLine("Size:              {0}", sizeof(Basecase1Int));
    Console.WriteLine("_byteValue Offset: {0}", &basecase1Int._byteValue - addr);
    Console.WriteLine("_intValue1 Offset: {0}", (byte*)&basecase1Int._intValue1 - addr);

    var memoryAligned1Int = new MemoryAligned1Int(1, 1);
    addr = (byte*) &memoryAligned1Int;
    Console.WriteLine("Size:              {0}", sizeof(MemoryAligned1Int));
    Console.WriteLine("_byteValue Offset: {0}", &memoryAligned1Int._byteValue - addr);
    Console.WriteLine("_intValue1 Offset: {0}", (byte*)&memoryAligned1Int._intValue1 - addr);
    
    var memoryMisaligned1Int = new MemoryMisaligned1Int(1, 1);
    addr = (byte*) &memoryMisaligned1Int;
    Console.WriteLine("Size:              {0}", sizeof(MemoryMisaligned1Int));
    Console.WriteLine("_byteValue Offset: {0}", &memoryMisaligned1Int._byteValue - addr);
    Console.WriteLine("_intValue1 Offset: {0}", (byte*)&memoryMisaligned1Int._intValue1 - addr);

    var basecase2Int = new Basecase2Int(1, 1, 1);
    addr = (byte*) &basecase2Int;
    Console.WriteLine("Size:              {0}", sizeof(Basecase2Int));
    Console.WriteLine("_byteValue Offset: {0}", &basecase2Int._byteValue - addr);
    Console.WriteLine("_intValue1 Offset: {0}", (byte*)&basecase2Int._intValue1 - addr);
    Console.WriteLine("_intValue2 Offset: {0}", (byte*)&basecase2Int._intValue2 - addr);

    var memoryAligned2Int = new MemoryAligned2Int(1, 1, 1);
    addr = (byte*) &memoryAligned2Int;
    Console.WriteLine("Size:              {0}", sizeof(MemoryAligned2Int));
    Console.WriteLine("_byteValue Offset: {0}", &memoryAligned2Int._byteValue - addr);
    Console.WriteLine("_intValue1 Offset: {0}", (byte*)&memoryAligned2Int._intValue1 - addr);
    Console.WriteLine("_intValue2 Offset: {0}", (byte*)&memoryAligned2Int._intValue2 - addr);
    
    var memoryMisaligned2Int = new MemoryMisaligned2Int(1, 1, 1);
    addr = (byte*) &memoryMisaligned2Int;
    Console.WriteLine("Size:              {0}", sizeof(MemoryMisaligned2Int));
    Console.WriteLine("_byteValue Offset: {0}", &memoryMisaligned2Int._byteValue - addr);
    Console.WriteLine("_intValue1 Offset: {0}", (byte*)&memoryMisaligned2Int._intValue1 - addr);
    Console.WriteLine("_intValue2 Offset: {0}", (byte*)&memoryMisaligned2Int._intValue2 - addr);
}

// Size:              8
// _byteValue Offset: 0
// _intValue1 Offset: 4
// Size:              8
// _byteValue Offset: 0
// _intValue1 Offset: 4
// Size:              8
// _byteValue Offset: 0
// _intValue1 Offset: 1
// Size:              12
// _byteValue Offset: 0
// _intValue1 Offset: 4
// _intValue2 Offset: 8
// Size:              12
// _byteValue Offset: 0
// _intValue1 Offset: 4
// _intValue2 Offset: 8
// Size:              12
// _byteValue Offset: 0
// _intValue1 Offset: 1
// _intValue2 Offset: 5

public readonly struct Basecase1Int
{
    public readonly byte _byteValue;

    public readonly int _intValue1;

    public Basecase1Int(byte byteValue, int intValue1)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
    }
}
[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryAligned1Int
{
    [FieldOffset(0)]
    public readonly byte _byteValue;

    [FieldOffset(4)]
    public readonly int _intValue1;

    public MemoryAligned1Int(byte byteValue, int intValue1)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryMisaligned1Int
{
    [FieldOffset(0)]
    public readonly byte _byteValue;

    [FieldOffset(1)]
    public readonly int _intValue1;

    public MemoryMisaligned1Int(byte byteValue, int intValue1)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
    }
}

public readonly struct Basecase2Int
{
    public readonly byte _byteValue;

    public readonly int _intValue1;

    public readonly int _intValue2;

    public Basecase2Int(byte byteValue, int intValue1, int intValue2)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
        _intValue2 = intValue2;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryAligned2Int
{
    [FieldOffset(0)]
    public readonly byte _byteValue;

    [FieldOffset(4)]
    public readonly int _intValue1;

    [FieldOffset(8)]
    public readonly int _intValue2;

    public MemoryAligned2Int(byte byteValue, int intValue1, int intValue2)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
        _intValue2 = intValue2;
    }
}

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryMisaligned2Int
{
    [FieldOffset(0)]
    public readonly byte _byteValue;

    [FieldOffset(1)]
    public readonly int _intValue1;

    [FieldOffset(5)]
    public readonly int _intValue2;

    public MemoryMisaligned2Int(byte byteValue, int intValue1, int intValue2)
    {
        _byteValue = byteValue;
        _intValue1 = intValue1;
        _intValue2 = intValue2;
    }
}
*/