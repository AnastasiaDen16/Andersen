using PullTest1_xUnit.MainFunctions;
using PullTest1_xUnit.Pages;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class SelectLanguageOnYandex : TestBase
    {
        [Fact]
        public void ChangeLanguageTest()
        {
            var mp = new MainPage();
            mp.ChangeLanguage();
            Assert.True(mp.CheckLang());
            Dispose();
        }
    }
}
