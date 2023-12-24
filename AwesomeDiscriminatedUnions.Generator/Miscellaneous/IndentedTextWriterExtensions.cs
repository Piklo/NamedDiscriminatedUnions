using System.CodeDom.Compiler;

namespace AwesomeDiscriminatedUnions.Generator.Miscellaneous;

internal static class IndentedTextWriterExtensions
{
    public static void WriteLineNoTabs(this IndentedTextWriter writer)
    {
        writer.WriteLineNoTabs(string.Empty);
    }
}
