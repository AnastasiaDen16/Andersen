using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit
{
    public class Wait
    {
        private static WebDriverWait wait = new WebDriverWait(BrowserManager.Driver, TimeSpan.FromSeconds(30));

        [Obsolete]
        static public void ForExists(By locator)
        {
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
