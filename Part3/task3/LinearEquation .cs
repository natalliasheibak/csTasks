using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class LinearEquation
    {
        private double _a;
        private double _b;
        private double _x;

        public double X
        {
            get
            {
                return this._x;
            }

            set
            {
                this._x = value;
            }
        }
        public LinearEquation(double a, double b)
        {
            this._a = a;
            this._b = b;
        }

        public LinearEquation(double a)
        {
            this._a = a;
            this._b = a;
        }

        public LinearEquation()
        {
            this._a = 0;
            this._b = 0;
        }

        public void Compute()
        {
            if (this._a == 0)
                throw new ArithmeticException();
            this._x = -(this._b / this._a);
        }

        public override string ToString()
        {
            string text = String.Format("{0}*x{1:+0.##;-0.##;0}=0:  ", this._a, this._b);
            text += String.Format("x={0:0.##}", this._x);
            return text;
        }
    }
}
