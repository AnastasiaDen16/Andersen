using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace PullTest1_xUnit.MainFunctions
{
    public sealed class BrowserManageMultiton
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome max window":
                    if (Driver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("start-maximized");
                        driver = new ChromeDriver(options);
                        Drivers.Add("Chrome max window", Driver);
                    }
                    break;

                case "Chrome incognito":
                    if (Driver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("incognito");
                        driver = new ChromeDriver(options);
                        Drivers.Add("Chrome incognito", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
        }

        public static void KillDriver()
        {
            if (Driver != null) Driver.Quit();
        }
    }
}
