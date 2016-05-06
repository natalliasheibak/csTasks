using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;

namespace task3.Condiment
{
    public class Mushrooms:PizzaCondiment
    {
        private decimal _price=decimal.Parse(Prices.Mushrooms);
        public override decimal Price
        {
            get
            {
                return _price + pizza.Price;
            }
        }

        public Mushrooms(Pizza pizza):base(pizza.Name+" + Mushrooms", pizza)
        {
            this.pizza = pizza;
        }
    }
}
