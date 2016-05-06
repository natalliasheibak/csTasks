using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;

namespace task3.Product
{
    class CheesePizza:Pizza
    {
        private decimal _price = decimal.Parse(Prices.CheesePizza);
        public override decimal Price
        {
            get
            {
                return _price;
            }
        }


        public CheesePizza():base("Cheese pizza"){ }
    }
}
