using OpenQA.Selenium;
using System;

namespace PullTest1_xUnit.MainFunctions
{
    public class TestBase : IDisposable
    {
        protected static IWebDriver driver;
        public TestBase()
        {
            Initialize();
        }

        public static void Initialize()
        {
            BrowserManageSingleton.InitDriver();
            driver = BrowserManageSingleton.Driver;
            driver.Manage().Window.Maximize();
            Wait.LoadPage();
            driver.Url = "https://yandex.by/";
        }

        public void Dispose()
        {
            BrowserManageSingleton.KillDriver();
        }
    }
}
