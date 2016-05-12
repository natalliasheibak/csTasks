using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;

namespace task1
{
    class WebDriver
    {
        private WebDriver() { }
        private static IWebDriver _driver = InitWebDriver();
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
        public static IWebDriver InitWebDriver()
        {
            if (_driver == null)
            {
                return DriverFactory.Create(ConfigurationManager.AppSettings["browser"]);
            }
            return _driver;
        }
    }
}
