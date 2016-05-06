using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class PrimeNumberDetector
    {
        public int Number { get; set; }

        public  PrimeNumberDetector(int number)
        {
            this.Number = number;
        }

        public void IsPrimary()
        {
            for (int i = 2; i < Number / 2; i++)
            {
                if (Number % i == 0)
                {
                    Console.WriteLine($"The number {this.Number} is not primary");
                    return;
                }
            }
            Console.WriteLine($"The number {this.Number} is primary");
        }
    }
}
