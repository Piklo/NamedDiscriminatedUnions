namespace AwesomeDiscriminatedUnions.Tests;

public sealed class EqualsTypeTests
{
    [Fact]
    public void None()
    {
        const string source = """
            using AwesomeDiscriminatedUnions;

            namespace TestNamespace;
                        
            [DiscriminatedUnion(equalsType: EqualsType.None)]
            [DiscriminatedUnionType(typeof(int))]
            public readonly partial struct JustIntUnion
            {
            }
            """;

        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().NotContain("IEquatable<JustIntUnion>"); // EqualsType.IEquatable
        res.Should().NotContain("public override readonly bool Equals"); // EqualsType.OverrideEquals
        res.Should().NotContain("public readonly bool Equals"); // EqualsType.EqualsStrict
        res.Should().NotContain("operator =="); // EqualsType.EqualsOperator
        res.Should().NotContain("operator !="); // EqualsType.EqualsOperator
    }

    [Fact]
    public void OverrideEquals()
    {
        const string source = """
            using AwesomeDiscriminatedUnions;

            namespace TestNamespace;
                        
            [DiscriminatedUnion(equalsType: EqualsType.OverrideEquals)]
            [DiscriminatedUnionType(typeof(int))]
            public readonly partial struct JustIntUnion
            {
            }
            """;

        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().NotContain("IEquatable<JustIntUnion>"); // EqualsType.IEquatable
        res.Should().Contain("""
                    public override readonly bool Equals([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object? obj)
                    {
                        if (obj is not JustIntUnion temp)
                        {
                            return false;
                        }
            
                        return Equals(temp);
                    }
            """); // EqualsType.OverrideEquals
        res.Should().NotContain("public readonly bool Equals"); // EqualsType.EqualsStrict
        res.Should().NotContain("operator =="); // EqualsType.EqualsOperator
        res.Should().NotContain("operator !="); // EqualsType.EqualsOperator
    }

    [Fact]
    public void EqualsStrict()
    {
        const string source = """
            using AwesomeDiscriminatedUnions;

            namespace TestNamespace;
                        
            [DiscriminatedUnion(equalsType: EqualsType.EqualsStrict)]
            [DiscriminatedUnionType(typeof(int))]
            public readonly partial struct JustIntUnion
            {
            }
            """;

        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().NotContain("IEquatable<JustIntUnion>"); // EqualsType.IEquatable
        res.Should().NotContain("public override readonly bool Equals"); // EqualsType.OverrideEquals
        res.Should().Contain("""
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
            """); // EqualsType.EqualsStrict
        res.Should().NotContain("operator =="); // EqualsType.EqualsOperator
        res.Should().NotContain("operator !="); // EqualsType.EqualsOperator
    }

    [Fact]
    public void IEquatable()
    {
        const string source = """
            using AwesomeDiscriminatedUnions;

            namespace TestNamespace;
                        
            [DiscriminatedUnion(equalsType: EqualsType.IEquatable)]
            [DiscriminatedUnionType(typeof(int))]
            public readonly partial struct JustIntUnion
            {
            }
            """;

        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().Contain("IEquatable<JustIntUnion>"); // EqualsType.IEquatable
        res.Should().NotContain("public override readonly bool Equals"); // EqualsType.OverrideEquals
        res.Should().NotContain("public readonly bool Equals"); // EqualsType.EqualsStrict
        res.Should().NotContain("operator =="); // EqualsType.EqualsOperator
        res.Should().NotContain("operator !="); // EqualsType.EqualsOperator
    }

    [Fact]
    public void EqualsOperator()
    {
        const string source = """
            using AwesomeDiscriminatedUnions;

            namespace TestNamespace;
                        
            [DiscriminatedUnion(equalsType: EqualsType.EqualsOperator)]
            [DiscriminatedUnionType(typeof(int))]
            public readonly partial struct JustIntUnion
            {
            }
            """;

        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().NotContain("IEquatable<JustIntUnion>"); // EqualsType.IEquatable
        res.Should().NotContain("public override readonly bool Equals"); // EqualsType.OverrideEquals
        res.Should().NotContain("public readonly bool Equals"); // EqualsType.EqualsStrict
        res.Should().Contain("public static bool operator ==(JustIntUnion left, JustIntUnion right) => left.Equals(right);"); // EqualsType.EqualsOperator
        res.Should().Contain("public static bool operator !=(JustIntUnion left, JustIntUnion right) => !(left == right);"); // EqualsType.EqualsOperator
    }

    [Fact]
    public void DefaultSettings()
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

        var res = GeneratorRunner.GetGeneratedOutput<Generator>(source);

        res.Should().Contain("IEquatable<JustIntUnion>"); // EqualsType.IEquatable
        res.Should().Contain("""
                    public override readonly bool Equals([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object? obj)
                    {
                        if (obj is not JustIntUnion temp)
                        {
                            return false;
                        }
            
                        return Equals(temp);
                    }
            """); // EqualsType.OverrideEquals
        res.Should().Contain("""
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
            """); // EqualsType.EqualsStrict
        res.Should().Contain("public static bool operator ==(JustIntUnion left, JustIntUnion right) => left.Equals(right);"); // EqualsType.EqualsOperator
        res.Should().Contain("public static bool operator !=(JustIntUnion left, JustIntUnion right) => !(left == right);"); // EqualsType.EqualsOperator
    }
}
