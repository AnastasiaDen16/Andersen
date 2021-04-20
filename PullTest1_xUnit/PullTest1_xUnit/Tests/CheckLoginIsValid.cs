using PullTest1_xUnit.MainFunctions;
using PullTest1_xUnit.Pages;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class CheckLoginIsValid : TestBase
    {
        private string InvalidLogin = "NoautotestLogin";

        [Fact]
        public void LoginIsValidTest()
        {
            var autorizPage = new AutorizationPage();
            var mainPage = new MainPage();
            mainPage.TransitionToMail();
            autorizPage.EnterLogin(InvalidLogin);
            Assert.True(autorizPage.IsInValidLog());
            Dispose();
        }
    }
}
