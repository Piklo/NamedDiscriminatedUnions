using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace NamedDiscriminatedUnions.Generator.Tests;

internal static class GeneratorRunner
{
    internal static Dictionary<string, string> GetGeneratedOutput<T>(string source, params string[] generatedFileNames)
        where T : IIncrementalGenerator, new()
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(source);
        var references = new List<MetadataReference>();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            if (!assembly.IsDynamic && !string.IsNullOrWhiteSpace(assembly.Location))
            {
                references.Add(MetadataReference.CreateFromFile(assembly.Location));
            }
        }

        references.Add(MetadataReference.CreateFromFile(typeof(DiscriminatedUnionAttribute).Assembly.Location));

        var compilation = CSharpCompilation.Create("foo", new SyntaxTree[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var generator = new T();

        var driver = CSharpGeneratorDriver.Create(generator);
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out var diagnostics);

        Assert.False(diagnostics.Any(d => d.Severity == DiagnosticSeverity.Error), $"Failed: {diagnostics.FirstOrDefault()?.GetMessage()}");

        var results = new Dictionary<string, string>();

        foreach (var filename in generatedFileNames)
        {
            var trees = outputCompilation.SyntaxTrees;
            var test = trees.First();
            var generatedTree = outputCompilation.SyntaxTrees.Single(tree => Path.GetFileName(tree.FilePath) == filename);
            var generatedCode = generatedTree.ToString();
            results[filename] = generatedCode;
        }

        return results;
    }
}
