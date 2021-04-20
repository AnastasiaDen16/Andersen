using OpenQA.Selenium;
using PullTest1_xUnit.MainFunctions;
using PullTest1_xUnit.Pages;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class NavigationOnYandex : TestBase
    {
        By TabLocator = By.XPath("//a[@aria-disabled='true']");
        By TabMaps = By.XPath("//div[@class='suggest']");
        By TabMarket = By.XPath("//a[@id='logoPartMarket']");
        By TabTranslate = By.XPath("//span[@class='logo-text']");
        By TabMusic = By.XPath("//a[@class='d-logo__ya-sub']");
        By Locator;
        NavigationTo nt = new NavigationTo();

        [Fact]
        public void VideoTest()
        {
            Locator = By.XPath("//a[@data-id='video']");
            Assert.True(nt.CheckNavigation(Locator, TabLocator));
            Dispose();
        }

        [Fact]
        public void ImageTest()
        {
            Locator = By.XPath("//a[@data-id='images']");
            Assert.True(nt.CheckNavigation(Locator, TabLocator));
            Dispose();
        }
        public void NewsTest()
        {
            Locator = By.XPath("//a[@data-id='news']");
            Assert.True(nt.CheckNavigation(Locator, TabLocator));
            Dispose();
        }

        [Fact]
        public void MapsTest()
        {
            Locator = By.XPath("//a[@data-id='maps']");
            Assert.True(nt.CheckNavigation(Locator, TabMaps));
            Dispose();
        }

        [Fact]
        public void MarketTest()
        {
            Locator = By.XPath("//a[@data-id='market']");
            Assert.True(nt.CheckNavigation(Locator, TabMarket));
            Dispose();
        }

        [Fact]
        public void TranslatorTest()
        {
            Locator = By.XPath("//a[@data-id='translate']");
            Assert.True(nt.CheckNavigation(Locator, TabTranslate));
            Dispose();
        }

        [Fact]
        public void MusicTest()
        {
            Locator = By.XPath("//a[@data-id='music']");
            Assert.True(nt.CheckNavigation(Locator, TabMusic));
            Dispose();
        }
    }
}
