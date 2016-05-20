using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using gmail.Pages.MailPages;
using gmail.Pages;
using gmail.Exceptions;
using gmail;

namespace tests
{
    [TestFixture]
    public class TestClass:BaseTestClass
    {
        [Test]
        public void firstTest()
        {
            IWebDriver driver = Driver.InitiateDriver();
            LoginPage page = new LoginPage(driver);
            page.Open();

            MainMailPage bpage=page.LogIn("natalya.sheyback@gmail.com", "47295631");
            //bpage.LogOut();
            bpage.GoToFolder(MainMailPage.Folder.Spam);
        }

    }
}
