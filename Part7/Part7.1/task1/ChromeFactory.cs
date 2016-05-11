using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace task1
{
    class ChromeFactory
    {
        private ChromeFactory() { }
        private static IWebDriver _driver = InitWebDriver();
        public static IWebDriver GetDriver()
        {
            return _driver;
        }
        public static IWebDriver InitWebDriver()
        {
            if (_driver == null)
            {
                return new ChromeDriver();
            }
            return _driver;
        }
    }
}
