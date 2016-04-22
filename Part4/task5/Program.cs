using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Rectangle rectangle1 = new Rectangle(double.Parse(RectangleData.height1), double.Parse(RectangleData.width1));
                Rectangle rectangle2 = new Rectangle(double.Parse(RectangleData.height2), double.Parse(RectangleData.width2));
                Console.WriteLine($"{rectangle1.ToString()} contains {rectangle1.ContainsOf(rectangle2)} of {rectangle2.ToString()}");
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
