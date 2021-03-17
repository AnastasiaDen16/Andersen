using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using PullTest1_xUnit.MainFunctions;
using Xunit;

namespace PullTest1_xUnit.Tests
{
    public class SelectLanguageOnYandex : TestBase
    {

        [Fact]
        public void ChangeLanguageTest()
        {
            ChangeLanguage();
            Assert.True(CheckLang());
            Dispose();
        }


        public void ChangeLanguage()
        {
            if (driver.FindElement(By.XPath("//li[@class='menu__list-item']/a/span[@class='menu__text']")).Text != "Eng")
            {
                driver.FindElement(By.XPath("//a[@class='home-link i-bem dropdown2__switcher home-link_black_yes']")).Click();
                driver.FindElement(By.XPath("//a[@class='menu__item menu__item_type_link']")).Click();
                CheckWindowsHandels.CheckWindowHandel();
                driver.FindElement(By.XPath("//button[@class='button select__button button_theme_normal button_arrow_down button_size_m i-bem button_js_inited']")).Click();
                driver.FindElement(By.XPath("//option[contains(text(),'English')]")).Click();
                driver.FindElement(By.XPath("//button[@class='button form__save button_theme_action button_size_m i-bem button_js_inited'])")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("a[@class='//menu__item menu__item_type_link']/parent::span[contains(text(),'Eng')]")).Click();
            }
        }

        public bool CheckLang()
        {
            return driver.FindElement(By.XPath("//a[@class='home-link i-bem dropdown2__switcher home-link_black_yes']")).Text == "Eng";
        }


    }
}
