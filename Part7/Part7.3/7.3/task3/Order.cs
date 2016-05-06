using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Condiment;
using task3.Product;

namespace task3
{
    class Order
    {
        Stack<Pizza> pizzas;

        public Order()
        {
            pizzas = new Stack<Pizza>();
        }

        public decimal GetOrderCost()
        {
            return pizzas.Sum(pizza => pizza.GetPrice());
        }

        public override string ToString()
        {
            StringBuilder order=new StringBuilder();
            order.AppendLine("Your order:");
            foreach(var pizza in pizzas)
            {
                order.AppendLine($"{pizza.Name} - {pizza.GetPrice():0.##}");
            }
            order.AppendLine($"Total cost: {this.GetOrderCost()}");
            return order.ToString();

        }

        public void AddPizza(int number)
        {
            Pizza pizza = null;
            switch (number)
            {
                case 1:
                    pizza = new VegetarianPizza();
                    break;
                case 2:
                    pizza = new CheesePizza();
                    break;
                case 3:
                    pizza = new MeatPizza();
                    break;
            }
            pizzas.Push(pizza);

        }

        public void AddCondimentToPizza(int number)
        {
            Pizza pizza = pizzas.Pop();
            PizzaCondiment condiment=null;
            switch (number)
            {
                case 1:
                    condiment = new Mushrooms(pizza);
                    break;
                case 2:
                    condiment = new Pepper(pizza);
                    break;
                case 3:
                    condiment = new Pepperoni(pizza);
                    break;
            }
            pizzas.Push(condiment);
        }
    }
}
