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
        }

        public bool CheckNavigation(By NavigationLocator)
        {
            NavigationTo.NavigationToPage(NavigationLocator);
            string mainWindowHandle = BrowserManager.Driver.CurrentWindowHandle;
            List<string> WindowHandles = new List<string>(BrowserManager.Driver.WindowHandles);
            Wait.ForVisible(TabLocator);
            return mainWindowHandle != WindowHandles[WindowHandles.Count - 1] & driver.FindElement(TabLocator).Displayed;
        }
    }
}
