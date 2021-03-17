using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit
{
    public class TestBase : IDisposable
    {
        public TestBase()
        {
            Initialize();
        }

        static public void Initialize()
        {
            BrowserManager.InitDriver();
            var driver = BrowserManager.Driver;
            driver.Manage().Window.Maximize();
            Wait.LoadPage();
            driver.Url = "https://yandex.by/";
        }

        public void Dispose()
        {
            BrowserManager.KillDriver();
        }
    }
}
