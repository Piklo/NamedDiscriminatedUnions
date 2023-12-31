namespace AwesomeDiscriminatedUnions.Generator.Tests.GeneratorTests.ConstructorTests;

public static class GenericConstructorsTests
{    /// <summary>
     /// T could be ref or value type, but for ref types default would be null, therefore it should be nullable
     /// </summary>
    [Fact]
    public static void NotNullableGenericParameterTypeIsNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NullableGenericParameterTypeIsNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NotNullableStructGenericParameterTypeIsNotNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : struct
                    {
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T value)");
    }

    [Fact]
    public static void NullableStructGenericParameterTypeIsNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : struct
                    {
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NotNullableClassGenericParameterTypeIsNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : class
                    {
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NullableClassGenericParameterTypeIsNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : class
                    {
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }
}
