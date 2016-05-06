using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;

namespace task3.Condiment
{
    class Pepperoni:PizzaCondiment
    {
        private decimal _price=decimal.Parse(Prices.Pepperoni);
        public override decimal Price
        {
            get
            {
                return _price + pizza.Price;
            }
        }

        public Pepperoni(Pizza pizza):base(pizza.Name + " + Pepperoni", pizza)
        {
            this.pizza = pizza;
        }
    }
}
