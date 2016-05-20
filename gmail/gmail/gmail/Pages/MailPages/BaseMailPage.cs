using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace gmail.Pages.MailPages
{
    public abstract class BaseMailPage:BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@class='gb_2a gbii']")]
        private IWebElement accountLink;

        [FindsBy(How = How.Id, Using = "gb_71")]
        private IWebElement exitLink;

        [FindsBy(How = How.XPath, Using = "//div[@class='z0']/div")]
        private IWebElement writeMsgButton;

        [FindsBy(How = How.Id, Using = ":eb")]
        private IWebElement toTextBox;

        [FindsBy(How = How.Id, Using = ":dm")]
        private IWebElement msgTextBox;

        [FindsBy(How = How.Id, Using = ":f1")]
        private IWebElement sendMessageButton;

        public BaseMailPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public LoginPage LogOut()
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            accountLink.Click();
            exitLink.Click();
            return new LoginPage(_driver);
        }

        public void SendMessageTo(string email, string message)
        {
            writeMsgButton.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            toTextBox.SendKeys(email);
            msgTextBox.SendKeys(message);
            sendMessageButton.Click();
        }
    }
}
