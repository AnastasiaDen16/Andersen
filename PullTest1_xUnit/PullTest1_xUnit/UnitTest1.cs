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
        private IWebDriver driver;
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";

        [Fact]
        public void Test1()
        {
            TransitionToSite();
            TransitionToMail();
            EnterLogin_Password();
            Assert.Equal(login, CheckLogin());
        }

        [Fact]
        public void Test2()
        {
            LogOut();
            Assert.True(CheckLogout());
        }

        public void TransitionToSite()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Url = "https://yandex.by/";
        }

        public void TransitionToMail()
        { 
            driver.FindElement(By.XPath("//a/parent::div[@class='desk-notif-card__card']")).Click();
        }
        string mainWindowHandle;
        List<string> WindowHandles;

        public void EnterLogin_Password()
        {
            mainWindowHandle = driver.CurrentWindowHandle;
            WindowHandles = new List<string>(driver.WindowHandles);
            int i = 0; string ChildWindow = WindowHandles[0];
            while (WindowHandles.Count>i)
            {
                if (mainWindowHandle != WindowHandles[i])
                {
                    driver.SwitchTo().Window(WindowHandles[i]);
                    mainWindowHandle = WindowHandles[i];
                }
                i++;
            }
            driver.FindElement(By.XPath("//input[@id='passp-field-login']")).SendKeys(login);
            driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//input[@id='passp-field-passwd']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit']")).Click();
        }

        public string CheckLogin()
        {
            WindowHandles = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(WindowHandles[WindowHandles.Count-1]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.FindElement(By.XPath("//a[@class='user-account user-account_left-name user-account_has-ticker_yes user-account_has-accent-letter_yes count-me legouser__current-account legouser__current-account i-bem']")).Click();
            string login = driver.FindElement(By.XPath("span[@class='user-account__name']")).Text;
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
