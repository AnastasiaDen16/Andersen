using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class UnitTest4
    {
        private static IWebDriver driver = null;
        private TestBase tb;

        [Fact]
        public void Test1()
        {
            YandexTest yt = new YandexTest(out tb, out driver);

        }
    }
}
