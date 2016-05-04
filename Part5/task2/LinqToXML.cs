using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Task
{
    public class LinqToXML
    {
        XDocument doc;
        public LinqToXML()
        {
            doc = XDocument.Load(Environment.CurrentDirectory + @"\Data\Customers.xml");
        }

        public List<string> Linq001(decimal number)
        {
            var customers = (from customer in doc.Element("customers").Elements("customer")
                        where customer.Element("orders")
                                .Elements("order")
                                .Count() > 0                                            //Выбрать всех клиентов, у которых есть заказы
                        && customer.Element("orders")
                            .Elements("order")
                            .Sum(order => decimal.Parse(order.Element("total").Value)) > number //И общая сумма заказов больше, чем заданное число
                        select customer.Element("id").Value).ToList();

            return customers;
        }

        public Dictionary<string, List<string>> Linq002()
        {
            var customersByCountry = (from customer in doc.Element("customers")
                                                .Elements("customer")
                                        group customer.Element("id").Value by customer.Element("country").Value) //Группировка по стране
                                        .ToDictionary(country => country.Key, customerCountry => customerCountry.ToList());                //Запись элементов в Dictionary с ключом - страной и элементом - списком всех клиентов в стране
            return customersByCountry;
        }

        public List<string> Linq003(decimal number)
        {
            var customers = (from customer in doc.Element("customers")
                                        .Elements("customer")   
                            from order in customer.Element("orders")       
                                        .Elements("order")
                            where decimal.Parse(order.Element("total").Value) > number
                            select customer.Element("id").Value).ToList();
            return customers;
        }

        public List<string> Linq004()
        {
            var customers = (from customer in doc.Element("customers")
                                          .Elements("customer")
                             where customer.Element("orders")
                                    .Elements("order").Any()                                                //Выбрать клиентов, у которых есть хотя бы один заказ
                             let startOrderDate = customer.Element("orders")
                                                  .Elements("order")
                                                  .Min(order => Convert.ToDateTime(order.Element("orderdate").Value))//Создать переменную с датой самого первого заказа
                             select customer.Element("id").Value+$" {startOrderDate:MM.yyyy}").ToList();

            return customers;
        }

        public List<string> Linq005()
        {
            var customers = (from customer in doc.Element("customers")
                                          .Elements("customer")
                             where customer.Element("orders")
                                    .Elements("order").Any()
                             let startOrderDate = customer.Element("orders")
                                                  .Elements("order")
                                                  .Min(order => Convert.ToDateTime(order.Element("orderdate").Value))
                             let totalSumOfOrders = customer.Element("orders")
                                                    .Elements("order")
                                                    .Sum(order => decimal.Parse(order.Element("total").Value))      //Переменная с суммой всех заказов клиента
                             orderby startOrderDate.Year,       
                                     startOrderDate.Month,
                                     totalSumOfOrders descending,
                                     customer.Element("id")
                             select customer.Element("id").Value + $" {startOrderDate:MM.yyyy} total:{totalSumOfOrders} ").ToList();
            return customers;

        }

        public List<string> Linq006()
        {
            string pattern = @"^[0-9-]+$";      //Шаблон строки только с числами и знаком тире
            var customers = (from customer in doc.Element("customers")
                                            .Elements("customer")
                             where (customer.Elements("postalcode").Any()
                                    && !Regex.IsMatch(customer.Element("postalcode").Value, pattern))      //если код не соответствует шаблону
                                    || !customer.Elements("region").Any()                                  //или отсутствует регион
                                    || !customer.Element("phone").Value.StartsWith("(")                    //или телефон без кода
                             select customer.Element("id").Value).ToList();

            return customers;
        }

        public List<string> Linq007()
        {

            var profitability = (from customer in doc.Element("customers").Elements("customer")
                                 group customer by customer.Element("city").Value     //группировка по городу
            into cities
                                 from city in cities
                                 select new
                                 {
                                     city = cities.Key,
                                     intensity = cities.Average(order => order.Element("orders")
                                                                .Elements("order")
                                                                .Count()),          //подсчет интенсивности
                                     profitability = cities.Sum(order => (order.Element("orders")
                                                                        .Elements("order")
                                                                        .Sum(sum => decimal.Parse(sum.Element("total").Value))))    
                                                    /cities.Sum(order=> (order.Element("orders").Elements("order").Count()))        //подсчет прибыльности
                                 })
                                 .Select(city=>$"{city.city}: profitability: {city.profitability:0.##}, intensity: {city.intensity:0.##}").ToList();
            return profitability;
        }

        public Dictionary<string,int> Linq008a()
        {
            var orders = (from customer in doc.Element("customers").Elements("customer")
                          from order in customer.Element("orders").Elements("order")
                          select order).ToList();           //полный список заказов
            var statisticByMonth = (from order in orders
                                    group order by Convert.ToDateTime(order.Element("orderdate").Value).Month)      //группировка по месяцу
                                               .OrderBy(c=>c.Key)                                           //сортировка
                                               .ToDictionary(c => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key), s => s.Count());   //сохранить в Dictionary с ключом - месяц и значением - количество заказов
            return statisticByMonth;
        }

        public Dictionary<int, int> Linq008b()
        {
            var orders = (from customer in doc.Element("customers").Elements("customer")
                          from order in customer.Element("orders").Elements("order")
                          select order).ToList();
            var statisticsByYear = (from order in orders
                                    group order by Convert.ToDateTime(order.Element("orderdate").Value).Year)
                                                .OrderBy(c => c.Key)
                                                .ToDictionary(c => c.Key, s => s.Count());
            return statisticsByYear;
        }

        public Dictionary<string, int> Linq008c()
        {
            var orders = (from customer in doc.Element("customers").Elements("customer")
                          from order in customer.Element("orders").Elements("order")
                          select order).ToList();
            var statisticsByMonthAndYear = (from order in orders
                                            group order by new      //группировка сначала по году, а потом по месяцу
                                            {
                                                year = Convert.ToDateTime(order.Element("orderdate").Value).Year,
                                                month = Convert.ToDateTime(order.Element("orderdate").Value).Month
                                            })
                                            .OrderBy(c => c.Key.year).ThenBy(c => c.Key.month)      //сортировка сначала по году, а потом по месяцу
                                            .ToDictionary(c => $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key.month):MMM} {c.Key.year}", s => s.Count());      //Dictionary ключ - месяц и год, значение - количество заказов

            return statisticsByMonthAndYear;
        }

    }

}
