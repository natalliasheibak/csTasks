using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Executioner executioner = new Executioner();
            Console.WriteLine("These are available functions for you:\n" +
                                "1. To compute the sum of a digit\n" +
                                "2. To compute distance between two points\n" +
                                "3. To find out whether the number is primary or not");
            
            executioner.Execute();
        }
    }
}
