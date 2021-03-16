using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit
{
    public class TestBase
    {
        public TestBase(out IWebDriver driver, string url)
        {
            Initialized(out driver, url);
        }

        static public void Initialized(out IWebDriver driver, string url)
        {
            BrowserManager.InitDriver();
            driver = BrowserManager.Driver;
            driver.Manage().Window.Maximize();
            Wait.LoadPage();
            driver.Url = url;
        }

        static public void Dispose()
        {
            BrowserManager.KillDriver();
        }
    }
}
