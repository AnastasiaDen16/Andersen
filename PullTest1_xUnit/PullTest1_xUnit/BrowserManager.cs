using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit
{
    public class BrowserManager
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("WebDriver instance was not initialized");
                return driver;
            }
        }

        public static void InitDriver()
        {
            if (driver==null) driver = new ChromeDriver();
        }

        public static void KillDriver(IWebDriver driver)
        {
            if (driver != null) driver.Close();
        }
    }
}
