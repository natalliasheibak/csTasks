using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(5, 4);
            Point point2 = new Point(5, 4);
            Point point3 = new Point(4, 5);

            Console.WriteLine(String.Format("Point with coordinates{0} and point with coordinates {1} are equal: {2}", point1.ToString(), point2.ToString(), point1.Equals(point2)));
            Console.WriteLine(String.Format("Point with coordinates{0} and point with coordinates {1} are equal: {2}", point1.ToString(), point3.ToString(), point1.Equals(point3)));
            Console.ReadLine();
        }
    }
}
