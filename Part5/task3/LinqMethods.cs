using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task3
{
    public class LinqMethods
    {
        private List<BigInteger> list=new List<BigInteger>();
        public LinqMethods(int number)
        {
            for (int i = 1; i < number; i++)
                list.Add(Calculator.Fibonacci(i));
        }

        public int Linq01()
        {
            var simpleNumbers = (from l in list
                                 where l.IsSimple()
                                 select l).Count();
            return simpleNumbers;
        }

        public int Linq02()
        {
            var dividesBySummOfDigits = (from l in list
                                         where l != 0 && l % (l.ToString().ToCharArray().Select(s => int.Parse(s.ToString())).Sum()) == 0
                                         select l).Count();
            return dividesBySummOfDigits;
        }

        public bool Linq03()
        {
            var divideBy5 = list.Any(n => (n % 5 == 0));
            return divideBy5;
        }

        public List<int> Linq04()
        {
            var squareRoots = (from l in list
                        where l.ToString().Contains('2')
                        select Convert.ToInt32(Math.Ceiling(BigInteger.Log(l, 2)))).ToList();
            return squareRoots;
        }

        public List<BigInteger> Linq05()
        {
            var orderedBySecondDigit = (from l in list
                        where l.ToString().Length > 1
                        orderby l.ToString().Substring(1, 1) descending
                        select l).ToList();
            return orderedBySecondDigit;
        }

        public void Linq06()
        {
            var task6 = from l in list
                        where l % 3 == 0 && l.ToString().Length>1
                        select list.GetRange(list.IndexOf(l) - 5, 10).ToList();
            int i = 1;
        }

        public BigInteger Linq07()
        {
            var number = (from l in list
                         let squareSum = (l.ToString().ToList().Select(s => (int.Parse(s.ToString()) * (int.Parse(s.ToString()))))).Sum()
                         orderby squareSum
                         select l)
             .Last();
            return number;
        }

        public double Linq08()
        {
            var averageZero = (from l in list
                         where l.ToString().Contains('0')
                         select l.ToString().ToArray().Where(s => s == '0').Count()).Sum() / list.Count;
            return averageZero;
        }
    }
    public static class Extension
    {
        public static bool IsSimple(this int number)
        {
            for (int n = 2; n < number / 2; n++)
            {
                if (number % n == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSimple(this BigInteger number)
        {
            for (BigInteger n = 2; n < number / 2; n++)
            {
                if (number % n == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod1()
        {
            LinqMethods linq = new LinqMethods(10);
            Assert.AreEqual(6, linq.Linq01());
        }

        [TestMethod]
        public void MyTestMethod6()
        {
            LinqMethods linq = new LinqMethods(100);
           // Assert.AreEqual(6, linq.Linq01());
        }

    }
}
