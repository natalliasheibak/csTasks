using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task3.Product
{
    class VegetarianPizza:Pizza
    {

        private decimal _price = decimal.Parse(Prices.VeganPizza);
        public override decimal Price
        {
            get
            {
                return _price;
            }
        }
        public VegetarianPizza():base("Vegan pizza") { }
    }
}
