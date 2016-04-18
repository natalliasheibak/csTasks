using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void summTest()
        {
            int a = 3;
            int b = 7;
            Calculator cal = new Calculator();
            Assert.AreEqual((a + b), cal.plus(a, b));
        }

        [TestMethod]
        public void minusTest()
        {
            int a = 7;
            int b = 3;
            Calculator cal = new Calculator();
            Assert.AreEqual((a - b), cal.minus(a, b));
        }

        [TestMethod]
        public void multiplyPest()
        {
            int a = 5;
            int b = 5;
            Calculator cal = new Calculator();
            Assert.AreEqual((a * b), cal.multiply(a, b));
        }

        [TestMethod]
        public void divideTest()
        {
            int a = 6;
            int b = 3;
            Calculator cal = new Calculator();
            Assert.AreEqual((a / b), cal.divide(a, b));
        }
    }
}
