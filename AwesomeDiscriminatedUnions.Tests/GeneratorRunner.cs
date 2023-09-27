using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AwesomeDiscriminatedUnions.Tests;

internal static class GeneratorRunner
{
    internal static string GetGeneratedOutput<T>(string source)
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

        var compilation = CSharpCompilation.Create("foo", new SyntaxTree[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var generator = new T();

        var driver = CSharpGeneratorDriver.Create(generator);
        driver.RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out var diagnostics);

        Assert.False(diagnostics.Any(d => d.Severity == DiagnosticSeverity.Error), $"Failed: {diagnostics.FirstOrDefault()?.GetMessage()}");

        var output = outputCompilation.SyntaxTrees.Last().ToString();

        return output;
    }
}
