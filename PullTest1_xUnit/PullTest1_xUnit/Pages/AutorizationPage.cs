﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using PullTest1_xUnit.MainFunctions;
using System.Collections.Generic;

namespace PullTest1_xUnit.Pages
{
    public class AutorizationPage
    {
        public void EnterLogin(string login)
        {
            By log = By.XPath("//input[@id='passp-field-login']");
            CheckWindowsHandels.CheckWindowHandel();
            Wait.ForVisible(log);
            BrowserManageSingleton.Driver.FindElement(log).SendKeys(login);
            BrowserManageSingleton.Driver.FindElement(By.XPath("//button/parent::div[@class='passp-button passp-sign-in-button']")).Click();

        }
        public void EnterPassword(string password)
        {
            By pass = By.XPath("//input[@id='passp-field-passwd']");
            Wait.ForVisible(pass);
            BrowserManageSingleton.Driver.FindElement(pass).SendKeys(password);
            BrowserManageSingleton.Driver.FindElement(By.XPath("//button[@class='Button2 Button2_size_l Button2_view_action Button2_width_max Button2_type_submit']")).Click();
        }

        By locatorLogin = By.XPath("//span[contains(@class,'username')]");

        public string CheckLogin()
        {
            //List<string> WindowHandles = new List<string>(BrowserManageSingleton.Driver.WindowHandles);
            //BrowserManageSingleton.Driver.SwitchTo().Window(WindowHandles[WindowHandles.Count - 1]);
            Wait.ForVisible(locatorLogin);
            string login = BrowserManageSingleton.Driver.FindElement(locatorLogin).Text;
            return login;
        }
        public bool IsInValidLog()
        {
            By invalidLog = By.XPath("//div[contains(text(),'Такого аккаунта нет')]");
            Wait.ForVisible(invalidLog);
            bool isValis = BrowserManageSingleton.Driver.FindElement(invalidLog).Displayed;
            return isValis;
        }
        public bool IsInValidPass()
        {
            By invalidPass = By.XPath("//div[contains(text(),'Неверный пароль')]");
            Wait.ForVisible(invalidPass);
            bool isValis = BrowserManageSingleton.Driver.FindElement(invalidPass).Displayed;
            return isValis;
        }

        public void LogOutWithoutLogin()
        {
            By user = By.XPath("//a[@class='home-link usermenu-link__control home-link_black_yes']");
            Wait.ForVisible(user);
            BrowserManageSingleton.Driver.FindElement(user).Click();
            BrowserManageSingleton.Driver.FindElement(By.XPath("//a[@id='uniq322']")).Click();
            BrowserManageSingleton.Driver.TakeScreenshot();
        }
        public void LogOutWithLogin()
        {
            By user = By.XPath("//div[@class='legouser legouser_fetch-accounts_yes legouser_hidden_yes i-bem']");
            Wait.ForVisible(user);
            BrowserManageSingleton.Driver.FindElement(user).Click();
            BrowserManageSingleton.Driver.FindElement(By.XPath("//a[@class='menu__item menu__item_type_link count-me legouser__menu-item legouser__menu-item_action_exit legouser__menu-item legouser__menu-item_action_exit']")).Click();
        }
        public bool CheckLogout()
        {
            bool logout = BrowserManageSingleton.Driver.FindElement(By.XPath("//div[@class='passp-button passp-sign-in-button']")).Displayed;
            return logout;
        }
        public void LogOut()
        {
            string login = "AutotestLogin";
            string password = "autotestPassword123";
            var autorizPage = new AutorizationPage();
            var mainPage = new MainPage();
            By user = By.XPath("//a/parent::div[@class='desk-notif-card__card']");
            if (BrowserManageSingleton.Driver.FindElement(user).Displayed)
            {
                mainPage.TransitionToMail();
                autorizPage.EnterLogin(login);
                autorizPage.EnterPassword(password);
                LogOutWithLogin();
            }
            else LogOutWithLogin();
        }
    }
}
