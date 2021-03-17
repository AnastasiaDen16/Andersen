using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit
{
    public class Wait
    {
        private static WebDriverWait wait = new WebDriverWait(BrowserManager.Driver, TimeSpan.FromSeconds(20));

        static public void ForVisible(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        static public void LoadPage()
        {
            wait.Until(dvr=>dvr.PageSource);
        }
    }
}
