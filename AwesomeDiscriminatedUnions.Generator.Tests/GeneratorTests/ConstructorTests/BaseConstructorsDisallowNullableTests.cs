namespace AwesomeDiscriminatedUnions.Generator.Tests.GeneratorTests.ConstructorTests;

/// <summary>
/// despite "disallowing nullable" constructors should allow nullable (if necessary), since we only pass one of the parameters with non default value
/// </summary>
public static class BaseConstructorsDisallowNullableTests
{
    [Fact]
    public static void NotValueTypeParameterIsNotNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNullable]
                        private readonly int value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int value)");
    }

    [Fact]
    public static void NullableValueTypeParameterIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNullable]
                        private readonly int? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int? value)");
    }

    [Fact]
    public static void NotNullableReferenceParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNullable]
                        private readonly string value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, string? value)");
    }

    [Fact]
    public static void NullableReferenceParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNullable]
                        private readonly string value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, string? value)");
    }
}
