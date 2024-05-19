namespace NamedDiscriminatedUnions.Generator.Tests.GeneratorTests.ConstructorTests;

/// <summary>
/// despite "disallowing null" constructors should allow null (if necessary), since we only pass one of the parameters with non default value
/// </summary>
public static class GenericConstructorsDisallowNullTests
{
    /// <summary>
    /// T could be reference or value type, but for reference types default would be null, therefore it should be nullable
    /// </summary>
    [Fact]
    public static void NotNullableGenericParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        [DisallowNull]
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NullableGenericParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                    {
                        [DisallowNull]
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NotNullableStructGenericParameterTypeIsNotNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : struct
                    {
                        [DisallowNull]
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T value)");
    }

    [Fact]
    public static void NullableStructGenericParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;

                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : struct
                    {
                        [DisallowNull]
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NotNullableClassGenericParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;

                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : class
                    {
                        [DisallowNull]
                        private readonly T value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }

    [Fact]
    public static void NullableClassGenericParameterTypeIsNullableDisallowNull()
    {
        const string source = """
                    using NamedDiscriminatedUnions.Attributes;
                                        
                    namespace TestNamespace;

                    [DiscriminatedUnion]
                    public readonly partial struct Union<T>
                        where T : class
                    {
                        [DisallowNull]
                        private readonly T? value;
                    }
                    """;
        const string generatedFileName = "Union.g.cs";

        var res = GeneratorRunner.GetGeneratedOutput<UnionGenerator>(source, generatedFileName)[generatedFileName];

        res.Should().Contain("private Union(Tag tag, T? value)");
    }
}
