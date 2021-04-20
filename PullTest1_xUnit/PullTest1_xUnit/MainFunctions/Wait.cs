using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PullTest1_xUnit.MainFunctions;
using System;

namespace PullTest1_xUnit
{
    public class Wait
    {
        private static WebDriverWait wait = new WebDriverWait(BrowserManageSingleton.Driver, TimeSpan.FromSeconds(20));

        static public void ForVisible(By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        static public void ForExist(By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        static public void LoadPage()
        {
            wait.Until(dvr=>dvr.PageSource);
        }
    }
}
