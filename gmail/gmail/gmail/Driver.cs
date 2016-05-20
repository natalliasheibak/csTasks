using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace gmail
{
    public class Driver
    {
        private static IWebDriver _driver;

        public static IWebDriver InitiateDriver()
        {
            if (_driver == null)
            {
                _driver = new FirefoxDriver();
            }
            return _driver;
        }
    }
}
