using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace task3
{
    class Calculator
    {
        public static BigInteger Fibonacci(int number)
        {
            BigInteger fibonacci = 1;
            BigInteger firstNum = 1;
            BigInteger secondNum = 1;
            if (number == 1 || number == 2)
            {
                return 1;
            }
            //else if (number <= 0)
            //{
            //    return 0;
            //}
            else
            {
                //fibonacci = Fibonacci(number - 1) + Fibonacci(number - 2);
                for (int i = 1; i < number; i++)
                {
                    fibonacci = firstNum + secondNum;
                    firstNum = secondNum;
                    secondNum = fibonacci;
                }
            }
            return fibonacci;


        }
    }

}
