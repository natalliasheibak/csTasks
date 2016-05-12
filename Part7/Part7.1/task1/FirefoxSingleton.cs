using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace task1
{
    class FirefoxSingleton
    {
        private FirefoxSingleton() { }
        private static IWebDriver _driver = InitWebDriver();
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
        public static IWebDriver InitWebDriver()
        {
            if (_driver == null)
            {
               return new FirefoxDriver();
            }
            return _driver;
        }
    }
}
