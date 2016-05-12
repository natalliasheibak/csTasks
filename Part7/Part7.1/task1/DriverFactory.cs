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
        public static IWebDriver Create(string browser)
        {
            switch (browser)
            {
                case "firefox":
                    return FirefoxSingleton.GetDriver();
                case "chrome":
                    return ChromeSingleton.GetDriver();
                default:
                    return FirefoxSingleton.GetDriver();
            }
        }
    }
}
