using OpenQA.Selenium;
using PullTest1_xUnit.MainFunctions;
using System.Collections.Generic;

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
            string mainWindowHandle = BrowserManageSingleton.Driver.CurrentWindowHandle;
            
            List<string> WindowHandles = new List<string>(BrowserManageSingleton.Driver.WindowHandles);
            driver.SwitchTo().Window(WindowHandles[WindowHandles.Count - 1]);
            Wait.ForExist(Tab);
            return driver.FindElement(Tab).Displayed;
        }
    }
}
