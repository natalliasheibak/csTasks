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
        public static List<BigInteger> Fibonacci(int number)
        {
            //BigInteger fibonacci;
            //if (number == 1 || number == 2)
            //{
            //    return 1;
            //}
            //else if (number <= 0)
            //{
            //    return 0;
            //}
            //else
            //{
            //    fibonacci = Fibonacci(number - 1) + Fibonacci(number - 2);
            //}
            //return fibonacci;

            List<BigInteger> fibonacciList = new List<BigInteger>();
            BigInteger[] f = new BigInteger[3];
            f[1] = 1;
            fibonacciList.Add(f[1]);
            for (int i = 2; i <= number; i++)
            {
                f[i % 3] = f[(i + 1) % 3] + f[(i + 2) % 3];
                fibonacciList.Add(f[i % 3]);
            }
            return fibonacciList;
        }
    }

}
