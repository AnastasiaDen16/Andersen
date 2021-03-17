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
    }
}
