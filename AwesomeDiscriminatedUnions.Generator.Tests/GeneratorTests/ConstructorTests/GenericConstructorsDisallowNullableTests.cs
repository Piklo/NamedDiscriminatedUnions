namespace AwesomeDiscriminatedUnions.Generator.Tests.GeneratorTests.ConstructorTests;

/// <summary>
/// despite "disallowing nullable" constructors should allow nullable (if necessary), since we only pass one of the parameters with non default value
/// </summary>
public static class GenericConstructorsDisallowNullableTests
{
    /// <summary>
    /// T could be ref or value type, but for ref types default would be null, therefore it should be nullable
    /// </summary>
    [Fact]
    public static void NotNullableGenericParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        [DisallowNullable]
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NullableGenericParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        [DisallowNullable]
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NotNullableStructGenericParameterTypeIsNotNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : struct
                    {
                        [DisallowNullable]
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T value)");
    }

    [Fact]
    public static void NullableStructGenericParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : struct
                    {
                        [DisallowNullable]
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NotNullableClassGenericParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : class
                    {
                        [DisallowNullable]
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NullableClassGenericParameterTypeIsNullableDisallowNullable()
    {
        const string source = """
                    using AwesomeDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : class
                    {
                        [DisallowNullable]
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }
}
