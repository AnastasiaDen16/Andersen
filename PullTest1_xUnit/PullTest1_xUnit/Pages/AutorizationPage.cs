using OpenQA.Selenium;
using PullTest1_xUnit.MainFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit.Pages
{
    public class AutorizationPage
    {
        public static void EnterLogin(string login)
        {
            By log = By.XPath("//input[@id='passp-field-login']");
            CheckWindowsHandels.CheckWindowHandel();
            Wait.ForVisible(log);
            BrowserManager.Driver.FindElement(log).SendKeys(login);
            BrowserManager.Driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']")).Click();

        }
        public static void EnterPassword(string password)
        {
            By pass = By.XPath("//input[@id='passp-field-passwd']");
            Wait.ForVisible(pass);
            BrowserManager.Driver.FindElement(pass).SendKeys(password);
            BrowserManager.Driver.FindElement(By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit']")).Click();
        }
    }
}
