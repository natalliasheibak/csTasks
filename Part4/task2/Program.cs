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
            Console.WriteLine("Input a number for calculation its factorial and Fibonacci number");
            int number;
            if (Int32.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine($"The fibonacci number = {Calculator.Fibonacci(number)} and factorial of this number = {Calculator.Factorial(number)}");
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
            Console.ReadLine();
        }
    }
}
