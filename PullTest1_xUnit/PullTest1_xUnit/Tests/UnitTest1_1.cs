using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace PullTest1_xUnit
{
    public class UnitTest1_1
    {
        private static IWebDriver driver = null;
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";

        [Fact]
        public void Test1()
        {
            YandexTest yt = new YandexTest();
            yt.TransitionToMail();
            yt.EnterLogin(login);
            yt.EnterPassword(password);
            Assert.Equal(login, CheckLogin());
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
