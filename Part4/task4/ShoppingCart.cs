using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class ShoppingCart
    {
        private List<Product> listOfProducts;
        public double TotalPrice {
            get
            {

            }
            private set
            {

            }
        }

        public ShoppingCart()
        {
            TotalPrice = 0;
            listOfProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            listOfProducts.Add(product);
            TotalPrice += product.ProductPrice;
        }

        public bool DeleteProduct(Product product)
        {
            if (listOfProducts.Remove(product))
            {
                TotalPrice -= product.ProductPrice;
                return true;
            }
            return false;
        }
    }
}
