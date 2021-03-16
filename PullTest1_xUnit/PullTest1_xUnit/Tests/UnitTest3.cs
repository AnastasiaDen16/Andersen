using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class UnitTest3
    {
        private static IWebDriver driver = null;
        private TestBase tb;

        [Fact]
        public void Test1()
        {
            YandexTest yt = new YandexTest();

        }
    }
}
