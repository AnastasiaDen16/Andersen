using PullTest1_xUnit.MainFunctions;
using PullTest1_xUnit.Pages;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class LogoutFromYandex:TestBase
    {
        [Fact]
        public void LodoutTest()
        {
            var autorizPage = new AutorizationPage();
            autorizPage.LogOut();
            Assert.True(autorizPage.CheckLogout());
            Dispose();
        }
    }
}
