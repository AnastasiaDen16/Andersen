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
        private string InvalidLogin = "NoautotestLogin";
        private string password = "NoAutotestPassword";

        [Fact]
        public void Test1()
        {
            YandexTest yt = new YandexTest();
            yt.TransitionToMail();
            yt.EnterLogin(login);
            yt.EnterPassword(password);
            Assert.True(IsInValidPass());
        }

        [Fact]
        public void Test2()
        {
            YandexTest yt = new YandexTest();
            yt.TransitionToMail();
            yt.EnterLogin(InvalidLogin);
            Assert.True(IsInValidLog());
        }

        public bool IsInValidPass()
        {
            By invalidPass = By.XPath("//div[contains(text(),'Неверный пароль')]");
            Wait.ForVisible(invalidPass);
            bool isValis = driver.FindElement(invalidPass).Displayed;
            return isValis;
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

