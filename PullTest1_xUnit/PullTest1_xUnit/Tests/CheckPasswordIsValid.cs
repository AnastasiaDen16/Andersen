using PullTest1_xUnit.MainFunctions;
using PullTest1_xUnit.Pages;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class CheckPasswordIsValid : TestBase
    {
        private string login = "AutotestLogin";
        private string password = "NoAutotestPassword";

        [Fact]
        public void PaaswordIsValidTest()
        {
            var autorizPage = new AutorizationPage();
            var mainPage = new MainPage();
            mainPage.TransitionToMail();
            autorizPage.EnterLogin(login);
            autorizPage.EnterPassword(password);
            Assert.True(autorizPage.IsInValidPass());
            Dispose();
        }
    }
}

