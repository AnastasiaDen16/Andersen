using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit
{
    public class YandexTest
    {
        IWebDriver driver;
        string mainWindowHandle;
        List<string> WindowHandles;

        public YandexTest(TestBase tb, out IWebDriver driver)
        {
            tb = new TestBase(out driver, "https://yandex.by/");
            this.driver = driver;
        }
        public void TransitionToMail()
        {
            driver.FindElement(By.XPath("//a/parent::div[@class='desk-notif-card__card']")).Click();
        }
        
        public void EnterLogin(string login)
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
            driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']")).Click();
            
        }
        public void EnterPassword(string password) 
        {
            By pass = By.XPath("//input[@id='passp-field-passwd']");
            Wait.ForVisible(pass);
            driver.FindElement(pass).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit']")).Click();
        }
    }
}
