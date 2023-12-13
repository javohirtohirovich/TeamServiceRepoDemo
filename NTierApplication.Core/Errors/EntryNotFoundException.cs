using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.Errors
{
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
}
