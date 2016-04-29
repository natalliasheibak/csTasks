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
            var customers = (from c in doc.Element("customers").Elements("customer")
                        where c.Element("orders")
                                .Elements("order")
                                .Count() > 0                                            //Выбрать всех клиентов, у которых есть заказы
                        && c.Element("orders")
                            .Elements("order")
                            .Sum(o => decimal.Parse(o.Element("total").Value)) > number //И общая сумма заказов больше, чем заданное число
                        select c.Element("id").Value).ToList();

            return customers;
        }

        public Dictionary<string, List<string>> Linq002()
        {
            var customersByCountry = (from c in doc.Element("customers")
                                                .Elements("customer")
                                        group c.Element("id").Value by c.Element("country").Value) //Группировка по стране
                                        .ToDictionary(o => o.Key, o => o.ToList());                //Запись элементов в Dictionary с ключом - страной и элементом - списком всех клиентов в стране
            return customersByCountry;
        }

        public List<string> Linq003(decimal number)
        {
            var customers = (from c in doc.Element("customers")
                                        .Elements("customer")   
                            from o in c.Element("orders")       
                                        .Elements("order")
                            where decimal.Parse(o.Element("total").Value) > number
                            select c.Element("id").Value).ToList();
            return customers;
        }

        public List<string> Linq004()
        {
            var customers = (from c in doc.Element("customers")
                                          .Elements("customer")
                             where c.Element("orders")
                                    .Elements("order").Any()                                                //Выбрать клиентов, у которых есть хотя бы один заказ
                             let startOrderDate = c.Element("orders")
                                                  .Elements("order")
                                                  .Min(o => Convert.ToDateTime(o.Element("orderdate").Value))//Создать переменную с датой самого первого заказа
                             select c.Element("id").Value+$" {startOrderDate:MM.yyyy}").ToList();

            return customers;
        }

        public List<string> Linq005()
        {
            var customers = (from c in doc.Element("customers")
                                          .Elements("customer")
                             where c.Element("orders")
                                    .Elements("order").Any()
                             let startOrderDate = c.Element("orders")
                                                  .Elements("order")
                                                  .Min(o => Convert.ToDateTime(o.Element("orderdate").Value))
                             let totalSumOfOrders = c.Element("orders")
                                                    .Elements("order")
                                                    .Sum(o => decimal.Parse(o.Element("total").Value))      //Переменная с суммой всех заказов клиента
                             orderby startOrderDate.Year,       
                                     startOrderDate.Month,
                                     totalSumOfOrders descending,
                                     c.Element("id")
                             select c.Element("id").Value + $" {startOrderDate:MM.yyyy} total:{totalSumOfOrders} ").ToList();
            return customers;

        }

        public List<string> Linq006()
        {
            string pattern = @"^[0-9-]+$";      //Шаблон строки только с числами и знаком тире
            var customers = (from c in doc.Element("customers")
                                            .Elements("customer")
                             where (c.Elements("postalcode").Any()
                                    && !Regex.IsMatch(c.Element("postalcode").Value, pattern))      //если код не соответствует шаблону
                                    || !c.Elements("region").Any()                                  //или отсутствует регион
                                    || !c.Element("phone").Value.StartsWith("(")                    //или телефон без кода
                             select c.Element("id").Value).ToList();

            return customers;
        }

        public List<string> Linq007()
        {

            var profitability = (from c in doc.Element("customers").Elements("customer")
                                 group c by c.Element("city").Value     //группировка по городу
            into cities
                                 from c in cities
                                 select new
                                 {
                                     city = cities.Key,
                                     intensity = cities.Average(o => o.Element("orders")
                                                                .Elements("order")
                                                                .Count()),          //подсчет интенсивности
                                     profitability = cities.Sum(o => (o.Element("orders")
                                                                        .Elements("order")
                                                                        .Sum(s => decimal.Parse(s.Element("total").Value))))    
                                                    /cities.Sum(o=> (o.Element("orders").Elements("order").Count()))        //подсчет прибыльности
                                 })
                                 .Select(c=>$"{c.city}: profitability: {c.profitability:0.##}, intensity: {c.intensity:0.##}").ToList();
            return profitability;
        }

        public Dictionary<string,int> Linq008a()
        {
            var orders = (from c in doc.Element("customers").Elements("customer")
                          from o in c.Element("orders").Elements("order")
                          select o).ToList();           //полный список заказов
            var statisticByMonth = (from o in orders
                                    group o by Convert.ToDateTime(o.Element("orderdate").Value).Month)      //группировка по месяцу
                                               .OrderBy(c=>c.Key)                                           //сортировка
                                               .ToDictionary(c => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key), s => s.Count());   //сохранить в Dictionary с ключом - месяц и значением - количество заказов
            return statisticByMonth;
        }

        public Dictionary<int, int> Linq008b()
        {
            var orders = (from c in doc.Element("customers").Elements("customer")
                          from o in c.Element("orders").Elements("order")
                          select o).ToList();
            var statisticsByYear = (from o in orders
                                    group o by Convert.ToDateTime(o.Element("orderdate").Value).Year)
                                                .OrderBy(c => c.Key)
                                                .ToDictionary(c => c.Key, s => s.Count());
            return statisticsByYear;
        }

        public Dictionary<string, int> Linq008c()
        {
            var orders = (from c in doc.Element("customers").Elements("customer")
                          from o in c.Element("orders").Elements("order")
                          select o).ToList();
            var statisticsByMonthAndYear = (from o in orders
                                            group o by new      //группировка сначала по году, а потом по месяцу
                                            {
                                                year = Convert.ToDateTime(o.Element("orderdate").Value).Year,
                                                month = Convert.ToDateTime(o.Element("orderdate").Value).Month
                                            })
                                            .OrderBy(c => c.Key.year).ThenBy(c => c.Key.month)      //сортировка сначала по году, а потом по месяцу
                                            .ToDictionary(c => $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Key.month):MMM} {c.Key.year}", s => s.Count());      //Dictionary ключ - месяц и год, значение - количество заказов

            return statisticsByMonthAndYear;
        }

    }

}
