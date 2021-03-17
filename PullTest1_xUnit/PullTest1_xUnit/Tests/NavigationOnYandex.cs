using OpenQA.Selenium;
using PullTest1_xUnit.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class NavigationOnYandex : TestBase
    {
        By TabLocator = By.XPath("//div[@class='tabs-navigation__tab-inner']");
        [Fact]
        public void Test1()
        {
            By Video = By.XPath("//a[@data-id='video']");
            Assert.True(CheckNavigation(Video));
            Dispose();
        }

        public bool CheckNavigation(By NavigationLocator)
        {
            NavigationTo.NavigationToPage(NavigationLocator);
            string mainWindowHandle = BrowserManager.Driver.CurrentWindowHandle;
            List<string> WindowHandles = new List<string>(BrowserManager.Driver.WindowHandles);
            driver.SwitchTo().Window(WindowHandles[WindowHandles.Count - 1]);
            Wait.ForExist(TabLocator);
            bool a = driver.FindElement(TabLocator).Displayed;
            return driver.FindElement(TabLocator).Displayed;
        }
    }
}
