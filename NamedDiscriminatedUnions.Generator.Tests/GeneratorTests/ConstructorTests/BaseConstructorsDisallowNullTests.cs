namespace NamedDiscriminatedUnions.Generator.Tests.GeneratorTests.ConstructorTests;

/// <summary>
/// despite "disallowing null" constructors should allow null (if necessary), since we only pass one of the parameters with non default value
/// </summary>
public static class BaseConstructorsDisallowNullTests
{
    [Fact]
    public static void NotNullableValueTypeParameterIsNotNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNull]
                        private readonly int value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int value)");
    }

    [Fact]
    public static void NullableValueTypeParameterIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNull]
                        private readonly int? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, int? value)");
    }

    [Fact]
    public static void NotNullableReferenceParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNull]
                        private readonly string value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, string? value)");
    }

    [Fact]
    public static void NullableReferenceParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union
                    {
                        [DisallowNull]
                        private readonly string value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, string? value)");
    }
}
