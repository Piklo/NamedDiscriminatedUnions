using System;
using System.CodeDom.Compiler;

namespace NamedDiscriminatedUnions.Generator.Miscellaneous;

internal static class IndentedTextWriterExtensions
{
    public static void WriteEmptyLine(this IndentedTextWriter writer)
    {
        writer.WriteLineNoTabs(string.Empty);
    }

    public static void WriteIndentedBlock(this IndentedTextWriter writer, Action<IndentedTextWriter> action)
    {
        writer.Indent++;
        action.Invoke(writer);
        writer.Indent--;
    }
}
