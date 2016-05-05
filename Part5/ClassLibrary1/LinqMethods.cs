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
                               select Convert.ToInt32(Math.Floor(Math.Exp(BigInteger.Log(l) / 2)))).ToList();
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

        public List<BigInteger> Linq06()
        {
            var indexOfElements = (from l in list
                        where l % 3 == 0
                        select list.IndexOf(l)).ToList();   //выбрать индексы элементов, которые делятся на 3
            var elementsInRangeOf5 = (from l in list
                      from t in indexOfElements
                      where list.IndexOf(l) >= (t - 5) && list.IndexOf(l) <= (t + 5) && l> 9     //проверить, входит ли индекс данного элемента в промежуток (индекс из indexOfElements-5, индекс+5)
                                      select l).Distinct().ToList();                             //удалить повторяющиеся

            var lastDigitsOfElementsDividedBy5 = (from t in elementsInRangeOf5
                      where t%5==0          //выбрать все, которые делятся на 5
                      select t % 100)       //взять последние 2 числа
                   .ToList();
            return lastDigitsOfElementsDividedBy5;
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
                         select l.ToString().ToArray().Where(s => s == '0').Count()).Sum() / Convert.ToDouble(list.Count);
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
            LinqMethods linq = new LinqMethods(1000);
            Assert.AreEqual(6, linq.Linq01());
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            LinqMethods linq = new LinqMethods(20);
            Assert.AreEqual(9,linq.Linq02());
        }

        [TestMethod]
        public void MyTestMethod3()
        {
            LinqMethods linq = new LinqMethods(20);
            Assert.AreEqual(true, linq.Linq03());
            linq = new LinqMethods(4);
            Assert.AreEqual(false, linq.Linq03());
        }

        [TestMethod]
        public void MyTestMethod4()
        {
            LinqMethods linq = new LinqMethods(20);
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(4);
            list.Add(15);
            list.Add(50);
            CollectionAssert.AreEqual(list, linq.Linq04());
        }

        [TestMethod]
        public void MyTestMethod5()
        {
            LinqMethods linq = new LinqMethods(20);
            Assert.AreEqual(89, linq.Linq05()[0]);
            Assert.AreEqual(4181, linq.Linq05()[12]);
        }


        [TestMethod]
        public void MyTestMethod6()
        {
            LinqMethods linq = new LinqMethods(20);
            List<BigInteger> list = new List<BigInteger>();
            list.Add(55);
            list.Add(10);
            CollectionAssert.AreEqual(list, linq.Linq06());
        }

        [TestMethod]
        public void MyTestMethod7()
        {
            LinqMethods linq = new LinqMethods(20);
            Assert.AreEqual(987, linq.Linq07());
        }

        [TestMethod]
        public void MyTestMethod8()
        {
            LinqMethods linq = new LinqMethods(20);
            Assert.AreEqual(0.05, Math.Round(linq.Linq08(),2));
        }
    }
}
