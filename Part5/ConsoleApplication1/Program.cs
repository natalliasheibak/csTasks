using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Task;

namespace task3
{
    public class Class1
    {
        public static void Main()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list=linq.Linq006();
            foreach (var l in list)
                Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}
