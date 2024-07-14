using System;

namespace NamedDiscriminatedUnions.Generator.Exceptions;

public class UnknownTagException : Exception
{
    public UnknownTagException()
    {
    }

    public UnknownTagException(string message) : base(message)
    {
    }

    public UnknownTagException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
