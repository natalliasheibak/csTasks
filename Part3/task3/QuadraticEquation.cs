using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class QuadraticEquation
    {
        private double _a;
        private double _b;
        private double _c;
        private double _x1;
        private double _x2;
        private double _d;

        public double X1
        {
            get
            {
                return this._x1;
            }
            set
            {
                this._x1 = value;
            }
        }

        public double X2
        {
            get
            {
                return this._x2;
            }
            set
            {
                this._x2 = value;
            }
        }
        public double D
        {
            get
            {
                return this._d;
            }
            set
            {
                this._d = value;
            }
        }

        public QuadraticEquation(double a, double b, double c)
        {
            this._a = a;
            this._b = b;
            this._c = c;
        }

        public QuadraticEquation(double a)
        {
            this._a = a;
            this._b = a;
            this._c = a;
        }

        public QuadraticEquation()
        {
            this._a = 0;
            this._b = 0;
            this._c = 0;
        }

        public void Compute()
        {
            this.CountD();
            if (this._a == 0)
            {
                try
                {
                    LinearEquation lEquation = new LinearEquation(this._b, this._c);
                    lEquation.Compute();
                    this._x1 = lEquation.X;
                    this._x2 = this._x1;
                }
                catch(ArithmeticException e)
                {
                    throw new ArithmeticException();
                }
            }
            else if (this._d < 0)
            {
                throw new ArithmeticException();
            }
            else if (this._d == 0)
            {
                this._x1= ((-1) * this._b) / (2 * this._a);
                this._x2 = this._x1;
            }
            else
            {
                this._x1 = ((-1) * this._b + Math.Sqrt(this._d)) / (2 * this._a);
                this._x2 = ((-1) * this._b - Math.Sqrt(this._d)) / (2 * this._a);
            }
            
        }

        private double CountD()
        {
            this._d = this._b * this._b - 4 * this._a * this._c;
            return this._d;
        }

        public override string ToString()
        {
            string text = String.Format("{0}*x^2{1:+0.##;-0.##;0}*x{2:+0.##;-0.##;0}=0:  ", this._a, this._b, this._c);
            text += String.Format("x1={0:0.##}, x2={1:0.##}", this._x1, this._x2);
            return text;
        }
    }
}
