using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using task1;

namespace task1.Test
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class Test
    {
        [TestMethod]
        public void TestDriverFactory()
        {
            using(var driver = DriverFactory.GetDriver())
            {
                driver.Navigate().GoToUrl("google.com");
            }
        }

        [TestMethod]
        public void TestFirefoxFactory()
        {
            using (var driver = FirefoxFactory.GetDriver())
            {
                driver.Navigate().GoToUrl("google.com");
            }
        }

        [TestMethod]
        public void TestChromeFactory()
        {
            using (var driver = ChromeFactory.GetDriver())
            {
                driver.Navigate().GoToUrl("google.com");
            }
        }
    }
}
