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
            ICommand command = null;
            int number;
            Console.WriteLine("These are available functions for you:\n" +
                                "1. To compute the sum of a digit\n" +
                                "2. To compute distance between two points\n" +
                                "3. To find out whether the number is primary or not");
            while (true)
            {
                Console.WriteLine("Select a number of command you wish to perform. To close the program type\"close\"");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Input a number for calculating");

                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            DigitSumCalculator digitSum = new DigitSumCalculator(number);
                            command = new DigitSumCommand(digitSum);
                        }
                        else
                        {
                            Console.WriteLine("You didn't entered number");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Input 4 numbers for calculating the distance between 2 points(ex.: x1 y1 x2 y2)");
                        int num = 0;
                        int[] numbers = Console.ReadLine().Split(' ').Where(n => int.TryParse(n, out num)).Select(n => int.Parse(n)).ToArray();
                        if (numbers.Length != 4)
                        {
                            Console.WriteLine("You didn't enter 4 numbers");
                            continue;
                        }
                        TwoPointDistanceCalculator twoPoints = new TwoPointDistanceCalculator(numbers[0], numbers[1], numbers[2], numbers[3]);
                        command = new DistanceCommand(twoPoints);
                        break;
                    case "3":
                        Console.WriteLine("Input a number for calculating");
                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            PrimeNumberDetector primeNumber = new PrimeNumberDetector(number);
                            command = new PrimaryNumberCommand(primeNumber);
                        }
                        else
                        {
                            Console.WriteLine("You didn't entered number");
                        }
                        break;
                    case "close":
                        return;
                    default:
                        continue;
                }
                command.Execute();
            }
        }
    }
}
