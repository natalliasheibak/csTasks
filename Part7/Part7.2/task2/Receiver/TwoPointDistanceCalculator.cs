using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class TwoPointDistanceCalculator
    {
        int X1 { get; set; }
        int Y1 { get; set; }
        int X2 { get; set; }
        int Y2 { get; set; }

        public TwoPointDistanceCalculator(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2; 
        }

        public void Distance()
        {
            double distance = Math.Sqrt(Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2));
            Console.WriteLine($"The distance between points ({X1},{Y1}) and ({X2},{Y2}) is equal {distance:0.##}");
        }
    }
}
