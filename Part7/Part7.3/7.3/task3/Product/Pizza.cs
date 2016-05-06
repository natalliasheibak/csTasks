using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task3.Product
{
    public abstract class Pizza
    {
        public abstract decimal Price { get; }
        public virtual int CondimentCount
        {
            get
            {
                return 0;
            }
        }
        public string Name { get; set; }

        public Pizza(string name)
        {
            this.Name = name;
        }

        public virtual decimal GetPrice()
        {
            return Price;
        }

    }
}
