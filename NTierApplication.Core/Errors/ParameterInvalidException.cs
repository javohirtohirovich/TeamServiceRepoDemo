using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.Errors
{
    [Serializable]
    public class ParameterInvalidException : Exception
    {
        public ParameterInvalidException() { }
        public ParameterInvalidException(string message) : base(message) { }
        public ParameterInvalidException(string message, Exception inner) : base(message, inner) { }
        protected ParameterInvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
