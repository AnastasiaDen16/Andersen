using PullTest1_xUnit.MainFunctions;
using PullTest1_xUnit.Pages;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class AutorizationToYandex : TestBase
    {
        private string login = "AutotestLogin";
        private string password = "autotestPassword123";

        [Fact]
        public void AutorizationTest()
        {
            var autorizPage = new AutorizationPage();
            var mainPage = new MainPage();
            mainPage.TransitionToMail();
            autorizPage.EnterLogin(login);
            autorizPage.EnterPassword(password);
            Assert.Equal(login, autorizPage.CheckLogin());
            Dispose();
        }
    }
}
