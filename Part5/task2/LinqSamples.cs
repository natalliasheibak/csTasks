// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;
using System.Text.RegularExpressions;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Where - Task 1")]
		[Description("This sample return all customers with summ of all orders more than a specified number")]

        public void Linq001()
        {
            Random rnd = new Random();
            decimal summ = (decimal)rnd.Next(10,100000);
            var customers = dataSource.Customers.
                Where(c => c.Orders.Sum(o=> o.Total)>summ).
                ToList();

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 2")]
        [Description("This sample return all suppliers that are situated in the same country")]

        public void Linq002()
        {

            var customers = from c in dataSource.Customers
                            from s in dataSource.Suppliers
                            where c.Country == s.Country
                            where c.City == s.City
                            group s.SupplierName by c.CustomerID;

                foreach (var c in customers)
                {
                    ObjectDumper.Write($"{c.Key}:");
                    ObjectDumper.Write(c);
                }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 2b")]
        [Description("This sample return all suppliers that are situated in the same country")]

        public void Linq002b()
        {

            var customers = from c in dataSource.Customers
                            from s in dataSource.Suppliers
                            where c.Country == s.Country
                            where c.City == s.City
                            select c.CustomerID+": "+s.SupplierName;

                foreach (var c in customers)
                {
                    ObjectDumper.Write(c);
                }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 3")]
        [Description("This sample return all customers with orders  which prices are higher than specified number")]

        public void Linq003()
        {
            Random rnd = new Random();
            decimal price = (decimal)rnd.Next(100, 3000);
            var customers = from c in dataSource.Customers
                            from o in c.Orders
                            where o.Total > price
                            select c;

            Console.WriteLine($"the number={price}");
            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 4")]
        [Description("This sample return list of customers with the date of their first order")]

        public void Linq004()
        {
            foreach (var c in dataSource.Customers)
            {
                if (c.Orders.Length == 0) continue;
                string message=$"{ c.CustomerID}: { c.Orders.Min(o => o.OrderDate):MM.yyyy}";
                ObjectDumper.Write(message);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 5")]
        [Description("This sample return list of customers with the date of their first order ordered by year, month, by summ of all orders and name ")]

        public void Linq005()
        {
            var customers = from c in dataSource.Customers
                            where c.Orders.Length>0
                            let firstOrderDate = c.Orders.Min(o => o.OrderDate)
                            let summOrder = c.Orders.Sum(o => o.Total)
                            orderby firstOrderDate.Year,
                            firstOrderDate.Month,
                            summOrder descending,
                            c.CompanyName
                            select c.CustomerID + " " + c.CompanyName + " " + summOrder + " " + firstOrderDate.Year + " " + firstOrderDate.Month;
                             

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 6")]
        [Description("This sample return list of customers with non-digital postalcode or without region or with phone number with no code")]

        public void Linq006()
        {
            string pattern = "[0-9]";
            var customers = from c in dataSource.Customers
                            
                            where //Regex.IsMatch(c1.PostalCode, "{1}")
                            c.Region == null
                            select c
                            into c1
                            where !c1.Phone.StartsWith("(")
                            select c1.CustomerID + " " + c1.PostalCode + " " + c1.Phone + " " + c1.Region;

            foreach (var c in customers)
            {
                ObjectDumper.Write(c);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 7")]
        [Description("This sample return grouped list of products by categories and by being in stock ordered by price")]

        public void Linq007()
        {
            var products = from p in dataSource.Products
                           group p by p.Category
                         into subproducts
                           from s in subproducts
                           orderby s.UnitPrice
                           let inStock = (s.UnitsInStock > 0) ? 1 : 0
                           group s by inStock;

            foreach (var p in products)
            {
                ObjectDumper.Write(p);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 8")]
        [Description("This sample return grouped list of products by ")]

        public void Linq008()
        {
            var products = from p in dataSource.Products
                           let price = (p.UnitPrice < 20) ? "low" : (p.UnitPrice < 60) ? "middle" : "high"
                           group p by price;

            foreach (var p in products)
            {
                ObjectDumper.Write(p.Key);
                ObjectDumper.Write(p);
            }
        }

        [Category("Restriction Operators")]
        [Title("Where - Task 9")]
        [Description("This sample return average profitability and intensity og each city")]

        public void Linq009()
        {
            var cities = from c in dataSource.Customers
                                from o in c.Orders
                                group o by c.City;
            var profitability = from c in cities
                                let average = c.Average(a => a.Total)
                                select c.Key+" "+average;
            var intensity= from c in dataSource.Customers
                           group c by c.City
                           into sub
                           from s in sub
                           let average=sub.Average(a=>s.Orders.Length)
                           select average;
            foreach (var p in profitability)
            {
                ObjectDumper.Write(p);
            }

        }
    }
}
