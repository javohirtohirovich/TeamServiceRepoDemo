using System.Runtime.Serialization;

namespace NTierApplication.Errors;

[Serializable]
public class EntryNotFoundException : Exception
{
    public EntryNotFoundException() { }
    public EntryNotFoundException(string message) : base(message) { }
    public EntryNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected EntryNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
