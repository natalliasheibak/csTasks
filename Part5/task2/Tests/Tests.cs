using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void MyTestMethod1()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list=linq.Linq001(5000);
            CollectionAssert.Contains(list, "MEREP");
            CollectionAssert.DoesNotContain(list, "ANATR");
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            LinqToXML linq = new LinqToXML();
            var dictionary = linq.Linq002();
            Assert.IsTrue(dictionary["USA"].Contains("HUNGC"));
        }

        [TestMethod]
        public void MyTestMethod3()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list = linq.Linq003(4000);
            CollectionAssert.Contains(list, "AROUT");
            CollectionAssert.DoesNotContain(list, "ANATR");
        }

        [TestMethod]
        public void MyTestMethod4()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list = linq.Linq004();
            CollectionAssert.Contains(list, "ALFKI 08.1997");
        }

        [TestMethod]
        public void MyTestMethod5()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list = linq.Linq005();
            Assert.IsTrue(list.First().Contains("ERNSH"));
        }

        [TestMethod]
        public void MyTestMethod6()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list = linq.Linq006();
            CollectionAssert.Contains(list, "BOTTM");
            CollectionAssert.Contains(list, "ANATR");
            CollectionAssert.Contains(list, "HUNGO");
        }

        [TestMethod]
        public void MyTestMethod7()
        {
            LinqToXML linq = new LinqToXML();
            List<string> list = linq.Linq007();
            CollectionAssert.Contains(list, "Mannheim: profitability: 462.83, intensity: 7");
        }

        [TestMethod]
        public void MyTestMethod8a()
        {
            LinqToXML linq = new LinqToXML();
            Dictionary<string,int>list =linq.Linq008a();
            Assert.AreEqual(list["May"],46);
        }

        [TestMethod]
        public void MyTestMethod8b()
        {
            LinqToXML linq = new LinqToXML();
            Dictionary<int, int> list = linq.Linq008b();
            Assert.AreEqual(list[1996], 152);
        }

        [TestMethod]
        public void MyTestMethod8c()
        {
            LinqToXML linq = new LinqToXML();
            Dictionary<string, int> list = linq.Linq008c();
            Assert.AreEqual(list["May 1997"], 32);
        }
    }
}
