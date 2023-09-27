namespace AwesomeDiscriminatedUnions.Tests;

public sealed class JustIntTests
{
    [Fact]
    public void Test()
    {
        const string source = """
            using AwesomeDiscriminatedUnions;

            namespace TestNamespace;

            [DiscriminatedUnion]
            [DiscriminatedUnionType(typeof(int))]
            public readonly partial struct JustIntUnion
            {
            }
            """;

        const string expected = """
            using System;
            using System.Runtime.InteropServices;

            #nullable enable

            namespace TestNamespace
            {
                [StructLayout(LayoutKind.Explicit)]
                partial struct JustIntUnion : IEquatable<JustIntUnion>
                {
                    private const byte TagNone = 0;
                    private const byte TagInt = 1;

                    [FieldOffset(0)]
                    private readonly byte _tag;

                    [FieldOffset(1)]
                    private readonly int _int;

                    public JustIntUnion(int value)
                    {
                        _int = value;
                        _tag = TagInt;
                    }

                    public readonly bool IsInt()
                    {
                        return _tag == TagInt;
                    }

                    public readonly bool IsInt(out int value)
                    {
                        if (_tag == TagInt)
                        {
                            value = _int;
                            return true;
                        }
                        value = default;
                        return false;
                    }

                    public readonly TResult Match<TResult>(Func<int, TResult> processInt)
                    {
                        switch (_tag)
                        {
                            case TagInt:
                                return processInt(_int);
                            default:
                                throw new AwesomeDiscriminatedUnions.ExhaustedMatchCasesException($"Unknown _tag = {_tag}");
                        }
                    }

                    public readonly void Switch(Action<int> processInt)
                    {
                        switch (_tag)
                        {
                            case TagInt:
                                processInt(_int);
                                return;
                            default:
                                throw new AwesomeDiscriminatedUnions.ExhaustedSwitchCasesException($"Unknown _tag = {_tag}");
                        }
                    }

                    public static implicit operator JustIntUnion(int value) => new JustIntUnion(value);

                    readonly public override int GetHashCode()
                    {
                        switch (_tag)
                        {
                            case TagInt:
                                return HashCode.Combine(_tag, _int);
                            default:
                                return 0;
                        }
                    }

                    public override readonly bool Equals([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object? obj)
                    {
                        if (obj is not JustIntUnion temp)
                        {
                            return false;
                        }

                        return Equals(temp);
                    }

                    public readonly bool Equals(JustIntUnion other)
                    {
                        if (_tag != other._tag)
                        {
                            return false;
                        }

                        switch (_tag)
                        {
                            case TagNone:
                                return true;
                            case TagInt:
                                return _int.Equals(other._int);
                            default:
                                return false;
                        }
                    }

                    public static bool operator ==(JustIntUnion left, JustIntUnion right) => left.Equals(right);

                    public static bool operator !=(JustIntUnion left, JustIntUnion right) => !(left == right);
                }
            }
            """;


        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().Contain(expected);
    }
}
