using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace task1.Test
{
    public class Test
    {
        [TestMethod]
        public void MyTestMethod()
        {
            using(var driver = DriverFactory.GetDriver())
            {
                driver.Navigate().GoToUrl("google.com");
            }
        }
    }
}
