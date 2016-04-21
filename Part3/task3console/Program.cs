using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using task3;

namespace task3console
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            string input;
            string[] coef;
            bool repeat = true;
            Console.WriteLine("What equation do you want to solve? Type \'q\' for quadratic, \'l\' for linear");
            string choice=Console.ReadLine();
            while (repeat)
            {

                switch (choice)
                {
                    case "q":
                        Console.WriteLine("Input coefficients(exmp. \"a b c\")");
                        input = Console.ReadLine();
                        coef = input.Split(' ');
                        if (coef.Length!=3||!double.TryParse(coef[0], out a) || !double.TryParse(coef[1], out b) || !double.TryParse(coef[2], out c))
                        {
                            Console.WriteLine("Incorrect input");
                            log("incorrect input: " + input);
                            break;
                        }
                        else
                        {
                            repeat = false;
                            try
                            {
                                QuadraticEquation qEquation = new QuadraticEquation(a, b, c);
                                qEquation.Compute();
                                Console.WriteLine("The roots of your equation are: x1={0:0.##}; x2={1:0.##}.", qEquation.X1, qEquation.X2);
                                log(qEquation.ToString());
                            }
                            catch (ArithmeticException e)
                            {

                                Console.WriteLine("The roots of this equation do not exist");
                                log("the roots do not exists: " + input);
                                break;
                            }
                        }
                        break;
                    case "l":
                        Console.WriteLine("Input coefficients(exmp. \"a b\")");
                        input = Console.ReadLine();
                        coef = input.Split(' ');
                        if (coef.Length!=2||!double.TryParse(coef[0], out a) || !double.TryParse(coef[1], out b))
                        {
                            Console.WriteLine("Incorrect input");
                            log("incorrect input: " + input);
                            break;
                        }
                        else
                        {
                            repeat = false;
                            try
                            {
                                LinearEquation lEquation = new LinearEquation(a, b);
                                lEquation.Compute();
                                Console.WriteLine("The root of your equation is: x={0:0.##}.", lEquation.X);
                                log(lEquation.ToString());
                            }
                            catch (ArithmeticException e)
                            {
                                Console.WriteLine("The roots of this equation do not exist");
                                log("the roots do not exists: " + input);
                                break;
                            }
                            break;
                        }
                    default:

                        Console.WriteLine("Incorrect input");
                        Console.WriteLine("What equation do you want to solve? Type \'q\' for quadratic, \'l\' for linear");
                        choice = Console.ReadLine();
                        break;
                }
            }
            Console.ReadLine();
        }

        public static void log(string text)
        {
            File.AppendAllText(@"C:\Users\Natallia_Sheibak@epam.com\Tracing\1.txt",(text+"\r\n"));
        }
    }
}
