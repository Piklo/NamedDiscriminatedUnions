using NamedDiscriminatedUnions.Tests;

namespace NamedDiscriminatedUnions.Tests.GeneratorTests.ConstructorTests;

public static class BaseConstructorsTests
{
    [Fact]
    public static void ConstructorIsPrivate()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int value)");
    }

    [Fact]
    public static void ConstructorWithMultipleParameters()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int value;
                        private readonly long value2;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int value, long value2)");
    }

    [Fact]
    public static void ConstructorAssignsValues()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int value;
                        private readonly long value2;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("""
                private Union(Tag tag, int value, long value2)
                {
                    this.tag = tag;
                    this.value = value;
                    this.value2 = value2;
                }
            """);
    }

    [Fact]
    public static void NotNullableValueTypeParameterIsNotNullable()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int value)");
    }

    [Fact]
    public static void NullableValueTypeParameterIsNullable()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int? value)");
    }

    [Fact]
    public static void NotNullableReferenceParameterTypeIsNullable()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly string value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, string? value)");
    }

    [Fact]
    public static void NullableReferenceParameterTypeIsNullable()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly string value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, string? value)");
    }
}
