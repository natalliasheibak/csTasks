using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class ElementDisabledException:System.Exception
    {
        public ElementDisabledException() : base() { }
        public ElementDisabledException(string message) : base(message) { }
        public ElementDisabledException(string message, System.Exception inner) : base(message, inner) { }
        public ElementDisabledException(System.Runtime.Serialization.SerializationInfo info,
                                        System.Runtime.Serialization.StreamingContext context) { }
    }
}
