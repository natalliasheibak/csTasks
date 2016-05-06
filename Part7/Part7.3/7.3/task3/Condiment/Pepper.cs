using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;

namespace task3.Condiment
{
    class Pepper:PizzaCondiment
    {
        private decimal _price=decimal.Parse(Prices.Pepper);
        public override decimal Price
        {
            get
            {
                return _price + pizza.Price;
            }
        }

        public Pepper(Pizza pizza):base(pizza.Name + " + Pepper", pizza)
        {
            this.pizza = pizza;
        }


    }
}
