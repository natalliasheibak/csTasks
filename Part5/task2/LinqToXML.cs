using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
                                .Count() > 0
                        && c.Element("orders")
                            .Elements("order")
                            .Sum(o => decimal.Parse(o.Element("total").Value)) > number
                        select c.Element("id").Value).ToList();

            return customers;
        }

        public List<string> Linq003(decimal number)
        {
            var customers = (from c in doc.Element("customers").Elements("customer")
                            from o in c.Element("orders").Elements("order")
                            where decimal.Parse(o.Element("total").Value) > number
                            select c.Element("id").Value).ToList();
            return customers;
        }

        public List<string> Linq004()
        {
            var customers = (from c in doc.Element("customers")
                                          .Elements("customer")
                             where c.Element("orders")
                                    .Elements("order").Any()
                             let startOrderDate = c.Element("orders")
                                                  .Elements("order")
                                                  .Min(o => Convert.ToDateTime(o.Element("orderdate").Value))
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
                                                    .Sum(o => decimal.Parse(o.Element("total").Value))
                             orderby startOrderDate.Year,
                                     startOrderDate.Month,
                                     totalSumOfOrders descending,
                                     c.Element("id")
                             select c.Element("id").Value + $" {startOrderDate:MM.yyyy} total:{totalSumOfOrders} ").ToList();
            return customers;

        }

        public List<string> Linq006()
        {
            string pattern = @"^\d+$";
            var customers = (from c in doc.Element("customers")
                                            .Elements("customer")
                             where (c.Elements("postalcode").Any() 
                                    && !Regex.IsMatch(c.Element("postalcode").Value, pattern))
                                    || !c.Elements("region").Any()
                                    || c.Element("phone").Value.Contains("(")
                             select $"{c.Element("id").Value} {c.Element("postalcode").Value} {c.Element("phone").Value}").ToList();

            return customers;
        }

        public List<string> Linq009()
        {

            var profitabilityAndIntensity= from c in doc.Element("customers")
                                                        .Elements("customer")
                                           
                                           group c by c.Element("city").Value
                                           into cities
                                           from customers in cities
                                           from orders in customers.Element("orders").Elements("order")
        }
    }
    //public class Tests
    //{
    //    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    //    public class MyTestClass
    //    {
    //        LinqToXML linq = new LinqToXML();
    //        List<string> list = linq.Linq001(500);

    //    }
    //}
}
