using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace PullTest1_xUnit
{
    public class UnitTest1
    {
        private static IWebDriver driver = null;
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";
        private TestBase tb;

        [Fact]
        public void Test1()
        {
            YandexTest yt = new YandexTest(tb, out driver);
            yt.TransitionToMail();
            yt.EnterLogin(login);
            yt.EnterPassword(password);
            Assert.Equal(login, CheckLogin());
            BrowserManager.KillDriver();
        }

        [Fact]
        public void Test2()
        {
            LogOut();
            Assert.True(CheckLogout());
        }

        By locatorLogin = By.XPath("//span[@class='user-account__name']");

        public string CheckLogin()
        {
            List<string> WindowHandles = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(WindowHandles[WindowHandles.Count-1]);
            Wait.ForVisible(locatorLogin);
            string login = driver.FindElement(locatorLogin).Text;
            return login;
        }
        public void LogOut()
        {
            driver.FindElement(By.XPath("//div[@class='legouser legouser_fetch-accounts_yes legouser_hidden_yes i-bem']")).Click();
            driver.FindElement(By.XPath("//a[@class='menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_exit legouser__menu-item legouser__menu-item_action_exit']"));
        }
        public bool CheckLogout()
        {
            bool logout = driver.FindElement(By.XPath("div[@class='passp-button passp-sign-in-button']")).Displayed;
            return logout;
        }
    }
}
