using System;
using System.Runtime.Serialization;

namespace NamedDiscriminatedUnions.Generator.Exceptions;
public class ExhaustedSwitchCasesException : Exception
{
    public ExhaustedSwitchCasesException()
    {
    }

    public ExhaustedSwitchCasesException(string message) : base(message)
    {
    }

    public ExhaustedSwitchCasesException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ExhaustedSwitchCasesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
