using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace PullTest2_xUnit
{
    public class UnitTest1
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
        public void Test2()
        {
            TransitionToSiteTest();
            TransitionToMailTest();
            EnterLogin();

            Assert.True(IsInValidLog());
        }

        public void TransitionToSiteTest()
        {
            //driver = new ChromeDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://yandex.by/";
        }

        public void TransitionToMailTest()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a/parent::div[@class='desk-notif-card__card']")).Click();
            //mailBtn.Click();
        }
        public void EnterLogin()
        {
            driver.FindElement(By.XPath("//input[@id='passp-field-login']")).SendKeys(login);
            driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']"));
        }
        public void EnterPassword()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait.Until(drv => drv.FindElement(By.XPath("//input[@id='passp-field-login']")));
            wait.Until(drv => drv.PageSource);

            driver.FindElement(By.Id("passp-field-passwd")).SendKeys(password);
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
