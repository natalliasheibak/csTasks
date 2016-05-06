using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task1
{
    public class DriverFactory
    {
        private DriverFactory() { }
        private static IWebDriver _driver = InitWebDriver();
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
        public static IWebDriver InitWebDriver()
        {
            switch (ConfigurationManager.AppSettings["browser"])
            {
                case "firefox":
                    return new FirefoxDriver();
                case "chrome":
                    return new ChromeDriver();
                default:
                    return new FirefoxDriver();
            }
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            using (var driver = DriverFactory.GetDriver())
            {
                driver.Navigate().GoToUrl("google.com");
            }
        }
    }
}
