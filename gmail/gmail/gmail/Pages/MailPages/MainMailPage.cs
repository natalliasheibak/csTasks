using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace gmail.Pages.MailPages
{
    public class MainMailPage : BaseMailPage
    {
        [FindsBy(How = How.Id, Using = "gbqfq")]
        private IWebElement searchBox;

        [FindsBy(How = How.Id, Using = "gbqfb")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//div[@id=':q9']/div/span")]
        private IWebElement selectAllCheckBox;

        [FindsBy(How = How.XPath, Using = "//div[@id=':q9']/div/div")]
        private IWebElement selectMenu;

        [FindsBy(How = How.Id, Using = ":3kh")]
        private IWebElement unreadMessagesSelector;

        public enum Folder
        {
            Inbox,
            Sent,
            Draft,
            Trash,
            Spam

        }

        public MainMailPage(IWebDriver driver) : base(driver) { }

        public void GoToFolder(Folder folder)
        {
            string folderString=null;
            switch (folder)
            {
                case Folder.Draft:
                    folderString = "in:draft";
                    break;
                case Folder.Inbox:
                    folderString = "in:inbox";
                    break;
                case Folder.Sent:
                    folderString = "in:sent";
                    break;
                case Folder.Spam:
                    folderString = "in:spam";
                    break;
                case Folder.Trash:
                    folderString = "in:trash";
                    break;
            }

            searchBox.SendKeys(folderString);
            searchButton.Click();
        }

        public void SellectAllMailFrom(string email)
        {
            searchBox.SendKeys(email);
            searchButton.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            selectAllCheckBox.Click();

        }
        public void SelectUnreadMailFrom(string email)
        {
            searchBox.SendKeys(email);
            searchButton.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            selectMenu.Click();
            unreadMessagesSelector.Click();
        }

    }
}
