using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class DigitSumCalculator
    {
        public int Number { get; set; }

        public DigitSumCalculator(int number)
        {
            this.Number = number;
        }

        public void Sum()
        {
            int sum = Number.ToString().Sum(digit => int.Parse(digit.ToString()));
            Console.WriteLine($"The sum of the digits of {this.Number} equals {sum}");
        }
    }
}
