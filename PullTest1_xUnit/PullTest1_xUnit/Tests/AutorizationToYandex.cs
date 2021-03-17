using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using PullTest1_xUnit.Pages;

namespace PullTest1_xUnit.Tests
{
    public class AutorizationToYandex:TestBase
    {
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";

        [Fact]
        public void AutorizationTest()
        {
            MainPage.TransitionToMail();
            AutorizationPage.EnterLogin(login);
            AutorizationPage.EnterPassword(password);
            Assert.Equal(login, CheckLogin());
            Dispose();
        }

        By locatorLogin = By.XPath("//span[@class='user-account__name']");

        public string CheckLogin()
        {
            List<string> WindowHandles = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(WindowHandles[WindowHandles.Count - 1]);
            Wait.ForVisible(locatorLogin);
            string login = driver.FindElement(locatorLogin).Text;
            return login;
        }
    }
}
