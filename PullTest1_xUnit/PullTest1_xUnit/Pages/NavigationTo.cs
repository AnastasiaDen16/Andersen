using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit.Pages
{
    public class NavigationTo:TestBase
    {
        public static void NavigationToPage(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public bool CheckNavigation(By NavigationLocator, By Tab)
        {
            NavigationTo.NavigationToPage(NavigationLocator);
            string mainWindowHandle = BrowserManager.Driver.CurrentWindowHandle;
            List<string> WindowHandles = new List<string>(BrowserManager.Driver.WindowHandles);
            driver.SwitchTo().Window(WindowHandles[WindowHandles.Count - 1]);
            Wait.ForExist(Tab);
            return driver.FindElement(Tab).Displayed;
        }
    }
}
