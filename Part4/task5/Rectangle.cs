using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Rectangle
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArithmeticException("The sides of the rectangle cannot be equal or less than zero");
            }
            this.Height = height;
            this.Width = width;
        }

        public int ContainsOf(Rectangle rectangle2)
        {
            if (this.RectangleArea() < rectangle2.RectangleArea())
            {
                return 0;
            }
            else
            {
                int number1 = (int)(this.Height / rectangle2.Height) * (int)(this.Width / rectangle2.Width);
                int number2 = (int)(this.Height / rectangle2.Width) * (int)(this.Width / rectangle2.Height);
                if (number1 >= number2)
                {
                    return number1;
                }
                else
                {
                    return number2;
                }
            }
        }

        public double RectangleArea()
        {
            return Height * Width;
        }

        public override string ToString()
        {
            return $"Rectangle with width = {this.Width} and height = {this.Height}";
        }
    }
}
