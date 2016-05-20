using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using gmail.Pages.MailPages;
using gmail.Exceptions;

namespace gmail.Pages
{
    public class LoginPage : BasePage
    {
        private WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement emailTextBox;

        [FindsBy(How = How.Id, Using = "Passwd")]
        private IWebElement passwordTextBox;

        [FindsBy(How = How.Id, Using = "next")]
        private IWebElement nextButton;

        [FindsBy(How = How.Id, Using = "signIn")]
        private IWebElement submitButton;

        [FindsBy(How = How.Id, Using = "email-display")]
        private IWebElement emailDisplay;

        [FindsBy(How = How.Id, Using = "errormsg_0_Email")]
        private IWebElement errorMsgEmailLabel;

        [FindsBy(How = How.Id, Using = "errormsg_0_Passwd")]
        private IWebElement errorMsgPasswordLabel;

        [FindsBy(How = How.XPath, Using = "//*[starts-with(@class, 'gb_b gb_7a')]")]
        private IWebElement emailLabel;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl("http://gmail.com");
        }

        public MainMailPage LogIn(string email, string password)
        {
            emailTextBox.SendKeys(email);
            nextButton.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            passwordTextBox.SendKeys(password);
            submitButton.Click();
            return new MainMailPage(_driver);
        }
    }
}
