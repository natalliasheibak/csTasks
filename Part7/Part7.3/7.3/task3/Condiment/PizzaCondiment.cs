using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;

namespace task3.Condiment
{
    public abstract class PizzaCondiment:Pizza
    {
        public Pizza pizza;
        public override int CondimentCount
        {
            get
            {
                return 1 + pizza.CondimentCount;
            }
        }
        public PizzaCondiment(string name, Pizza pizza):base(name)
        {
            this.pizza = pizza;
        }

        public override decimal GetPrice()
        {
            if (this.CondimentCount >= 2)
            {
                return this.Price *0.95M;
            }
            return this.Price;
        }

    }
}
