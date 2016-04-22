using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class ClassWithCount
    {
        public ClassWithCount()
        {
            addExemplar();
        }
        public static int ExemplarCount { get; private set; }
        public static int addExemplar()
        {
            return ++ExemplarCount;
        }
    }
}
