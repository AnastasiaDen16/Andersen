using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PullTest1_xUnit.Pages;
using System;
using System.Collections.Generic;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class CheckPasswordIsValid:TestBase
    {
        private string login = "AutotestLogin";
        private string password = "NoAutotestPassword";

        [Fact]
        public void PaaswordIsValidTest()
        {
            MainPage.TransitionToMail();
            AutorizationPage.EnterLogin(login);
            AutorizationPage.EnterPassword(password);
            Assert.True(IsInValidPass());
            Dispose();
        }

        public bool IsInValidPass()
        {
            By invalidPass = By.XPath("//div[contains(text(),'Неверный пароль')]");
            Wait.ForVisible(invalidPass);
            bool isValis = driver.FindElement(invalidPass).Displayed;
            return isValis;
        }
    }
}

