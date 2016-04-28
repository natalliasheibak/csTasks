using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    static class Calculator
    {
        public static int Fibonacci(int number)
        {
            int fibSentence = 0;
            if (number == 2 || number == 1)
            {
                return 1;
            }
            else if (number > 2)
            {
                fibSentence = Calculator.Fibonacci(number - 1) + Calculator.Fibonacci(number - 2);
            }
            return fibSentence;
        }

        public static int Factorial(int number)
        {
            int multNumber = 0;
            if (number == 1)
            {
                return number;
            }
            else if (number > 1)
            {
                multNumber = number * Calculator.Factorial(number - 1);
            }
            return multNumber;
        }
    }
}
