using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Calculator
    {
        public int plus(int a, int b)
        {
            return a + b;
        }

        public int minus(int a, int b)
        {
            return a - b;
        }

        public int multiply(int a, int b)
        {
            return a * b;
        }

        public double divide(int a, int b)
        {
            try
            {
                double c = a / b;
                return c;
            }
            catch(DivideByZeroException e)
            {
                return 0;
            }
        }
    }
}
