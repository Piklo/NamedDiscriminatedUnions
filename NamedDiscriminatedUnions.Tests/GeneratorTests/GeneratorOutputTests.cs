namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class GeneratorOutputTests
{
    [Fact]
    public static void EmptyUnionGeneratesNothing()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Empty
                    {
                    }
                    """;
        const string generatedFileName = "Empty.g.cs";

        var act = () => GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName);

        // kind of hacky cuz we don't test whether generator outputs nothing but whether our generator runner can't find the result
        // in the end it's the same result though
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public static void UnionGeneratesSomething()
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

        var files = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName);

        files.ContainsKey(generatedFileName).Should().BeTrue();
    }

    [Fact]
    public static void GenericUnionGeneratesWithCorrectName()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union`1.g.cs";

        var files = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName);

        files.ContainsKey(generatedFileName).Should().BeTrue();
    }

    [Fact]
    public static void GenericUnionGeneratesWithCorrectName2()
    {
        const string source = """
                    using NamedDiscriminatedUnions;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<K, V>
                    {
                        private readonly T value;
                        private readonly V value2;
                    }
                    """;
        const string generatedFileName = "Union`2.g.cs";

        var files = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName);

        files.ContainsKey(generatedFileName).Should().BeTrue();
    }
}
