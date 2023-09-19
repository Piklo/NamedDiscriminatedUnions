using System;

namespace AwesomeDiscriminatedUnionsExample;

internal class Program
{
    static void Main()
    {
        var union = new MyTestUnion(123);
        if (union.IsInt(out var item))
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Hello, World!");
    }
}