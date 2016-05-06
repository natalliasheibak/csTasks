using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task3.Product;
using task3.Condiment;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            bool pizzaCycle = true;
            while (pizzaCycle)
            {
                Console.WriteLine(@"Availibale pizza:
                                1. Vegetarian pizza
                                2. Cheese pizza
                                3. Meat pizza");
                Console.WriteLine("Type a number of pizza you would like to order.");
                string choice = Console.ReadLine();
                int number = 0;
                bool condimentCycle = true;
                if ((int.TryParse(choice, out number)) && (number >= 1 && number <= 3))
                {
                    order.AddPizza(number);
                    while (condimentCycle)
                    {
                        Console.WriteLine("Would you like to add some(more) condiment to your pizza(yes/no)");
                        switch (Console.ReadLine())
                        {
                            case "yes":
                                Console.WriteLine(@"Availibale condiment:
                                 1. Mushrooms
                                 2. Pepper
                                 3. Pepperoni");
                                choice = Console.ReadLine();
                                if ((int.TryParse(choice, out number)) && (number >= 1 && number <= 3))
                                {
                                    order.AddCondimentToPizza(number);
                                }
                                continue;
                            case "no":
                                condimentCycle = false;
                                break;
                            default:
                                continue;
                        }
                    }
                    Console.WriteLine("Would you like to order some more pizza(yes/no)");
                    switch (Console.ReadLine())
                    {
                        case "yes":
                            continue;
                        case "no":
                        default:
                            pizzaCycle = false;
                            break;
                    }
                }
            }
            Console.WriteLine(order.ToString());
            Console.ReadLine();
        }
    }
}
