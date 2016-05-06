using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;

namespace task3.Product
{
    class MeatPizza:Pizza
    {
        private decimal _price = decimal.Parse(Prices.MeatPizza);
        public override decimal Price
        {
            get
            {
                return _price;
            }
        }

        public MeatPizza():base("Meat pizza") { }
    }
}
