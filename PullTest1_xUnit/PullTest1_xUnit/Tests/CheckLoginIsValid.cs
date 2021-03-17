using OpenQA.Selenium;
using PullTest1_xUnit.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class CheckLoginIsValid:TestBase
    {
        private string InvalidLogin = "NoautotestLogin";
        
        [Fact]
        public void LoginIsValidTest()
        {
            MainPage.TransitionToMail();
            AutorizationPage.EnterLogin(InvalidLogin);
            Assert.True(IsInValidLog());
            Dispose();
        }

        public bool IsInValidLog()
        {
            By invalidLog = By.XPath("//div[contains(text(),'Такого аккаунта нет')]");
            Wait.ForVisible(invalidLog);
            bool isValis = driver.FindElement(invalidLog).Displayed;
            return isValis;
        }
    }
}
