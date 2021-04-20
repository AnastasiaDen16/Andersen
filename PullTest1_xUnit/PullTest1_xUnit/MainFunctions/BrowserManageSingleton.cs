using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace PullTest1_xUnit.MainFunctions
{
    public sealed class BrowserManageSingleton
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
            var chromeOptions = new ChromeOptions()
            {
                PlatformName = "Windows 10",
                UseSpecCompliantProtocol = true
            };
            if (driver == null) driver = new RemoteWebDriver(new Uri("http://192.168.85.87:4444/wd/hub"), chromeOptions.ToCapabilities());
        }

        public static void KillDriver()
        {
            if (driver != null) driver.Quit();
        }
    }
}
