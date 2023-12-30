namespace AwesomeDiscriminatedUnions.Generator.Tests.GeneratorTests;

public static class TagFieldTests
{
    [Fact]
    public static void FieldEnumGeneratesCorrectly()
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

        res.Should().Contain("private readonly Tag tag;");
    }
}
