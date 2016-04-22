using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Point
    {
        private double _x;
        private double _y;

        public double X { get
            {
                return this._x;
            }
             set
            {
                this._x = value;
            }
        }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public override string ToString()
        {
            return String.Format("x={0}, y={1}",this._x, this._y) ;
        }

        public override bool Equals(object obj)
        {
            Point externalPoint = obj as Point;
            if (externalPoint != null)
            {
                bool result = (this._x == externalPoint._x || this._y == externalPoint._y) ? true : false;
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}
