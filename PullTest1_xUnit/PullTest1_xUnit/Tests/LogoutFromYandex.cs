using OpenQA.Selenium;
using PullTest1_xUnit.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class LogoutFromYandex:TestBase
    {
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";

        [Fact]
        public void LodoutTest()
        {
            LogOut();
            Assert.True(CheckLogout());
            Dispose();
        }

        public void LogOut()
        {
            By user = By.XPath("//a/parent::div[@class='desk-notif-card__card']");
            if (driver.FindElement(user).Displayed)
            {
                MainPage.TransitionToMail();
                AutorizationPage.EnterLogin(login);
                AutorizationPage.EnterPassword(password);
                LogOutWithLogin();
            }
            else LogOutWithLogin();
        }

        public void LogOutWithoutLogin()
        {
            By user = By.XPath("//a[@class='home-link usermenu-link__control home-link_black_yes']");
            Wait.ForVisible(user);
            driver.FindElement(user).Click();
            driver.FindElement(By.XPath("//a[@id='uniq322']")).Click();
        }
        public void LogOutWithLogin()
        {
            By user = By.XPath("//div[@class='legouser legouser_fetch-accounts_yes legouser_hidden_yes i-bem']");
            Wait.ForVisible(user);
            driver.FindElement(user).Click();
            driver.FindElement(By.XPath("//a[@class='menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_exit legouser__menu-item legouser__menu-item_action_exit']")).Click();
        }
        public bool CheckLogout()
        {
            bool logout = driver.FindElement(By.XPath("//div[@class='passp-button passp-sign-in-button']")).Displayed;
            return logout;
        }
    }
}
