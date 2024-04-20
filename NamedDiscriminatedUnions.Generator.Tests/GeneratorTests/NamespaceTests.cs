namespace AwesomeDiscriminatedUnions.Generator.Tests.GeneratorTests;

public static class NamespaceTests
{

    [Fact]
    public static void UnionIsGeneratedInTheRightNamespace()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int _value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("namespace TestNamespace;");
    }

    [Fact]
    public static void UnionCanBeGeneratedWithoutNamespace()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        private readonly int _value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().NotContain("namespace");
    }
}
