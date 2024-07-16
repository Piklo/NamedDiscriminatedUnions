namespace NamedDiscriminatedUnions.Tests.GeneratorTests;

public static class EmptyUnionTests
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
        const string generatedFileName = "Union.g.cs";

        var act = () => GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName);

        // kind of hacky cuz we don't test whether generator outputs nothing but whether our generator runner can't find the result
        // in the end it's the same result though
        act.Should().Throw<InvalidOperationException>();
    }
}
