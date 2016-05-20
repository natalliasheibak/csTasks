using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace gmail.Pages
{
    public abstract class BasePage
    {
        public IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
