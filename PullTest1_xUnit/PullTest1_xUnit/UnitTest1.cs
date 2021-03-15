using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PullTest1_xUnit
{
    public class UnitTest1
    {
        private IWebDriver driver;
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";
        //[FindsBy(How = How.XPath, Using = "//a/parent::div[@class='desk-notif-card__card']")]
        // private IWebElement mailBtn;
        [Fact]
        public void Test1()
        {
            TransitionToSiteTest();
            TransitionToMailTest();
            EnterLogin_Password();

            Assert.Equal(login, CheckLogin());
        }
        [Fact]
        public void Test2()
        {
            LogOut();

            Assert.True(CheckLogout());
        }

        public void TransitionToSiteTest()
        {
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

        public void EnterLogin_Password()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait.Until(drv => drv.FindElement(By.XPath("//input[@id='passp-field-login']")));
            wait.Until(drv => drv.PageSource); 
            driver.FindElement(By.XPath("//input[@id='passp-field-login']")).SendKeys(login);
            driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']"));
            driver.FindElement(By.Id("passp-field-passwd")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit'"));
        }

        public string CheckLogin()
        {
            string login = driver.FindElement(By.XPath("span[@class='user -account__name']")).Text;
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
