using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Xunit;

namespace PullTest1_xUnit
{
    public class UnitTest2
    {
        private IWebDriver driver;
        private string login = "AutotestLogin";
        private string password = "NoAutotestPassword";

        [Fact]
        public void Test1()
        {
            TransitionToSiteTest();
            TransitionToMailTest();
            EnterLogin();
            EnterPassword();
            Assert.True(IsInValidPass());
        }

        [Fact]
        public void Test2()
        {
            TransitionToSiteTest();
            TransitionToMailTest();
            EnterLogin();
            Assert.True(IsInValidLog());
        }

        public void TransitionToSiteTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Url = "https://yandex.by/";
        }

        public void TransitionToMailTest()
        {
            driver.FindElement(By.XPath("//a/parent::div[@class='desk-notif-card__card']")).Click();
        }

        string mainWindowHandle;
        List<string> WindowHandles;

        public void EnterLogin()
        {
            mainWindowHandle = driver.CurrentWindowHandle;
            WindowHandles = new List<string>(driver.WindowHandles);
            int i = 0; string ChildWindow = WindowHandles[0];
            while (WindowHandles.Count > i)
            {
                if (mainWindowHandle != WindowHandles[i])
                {
                    driver.SwitchTo().Window(WindowHandles[i]);
                    mainWindowHandle = WindowHandles[i];
                }
                i++;
            }
            driver.FindElement(By.XPath("//input[@id='passp-field-login']")).SendKeys(login);
            driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']"));
        }

        public void EnterPassword()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("passp-field-passwd")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit'"));
        }

        public bool IsInValidPass()
        {
            bool isValis = driver.FindElement(By.XPath("div[contains(text(),'Неверный пароль')]")).Displayed;
            return isValis;
        }
        public bool IsInValidLog()
        {
            bool isValis = driver.FindElement(By.XPath("div[contains(text(),'Такого аккаунта нет')]")).Displayed;
            return isValis;
        }
    }
}

