using OpenQA.Selenium;
using PullTest1_xUnit.MainFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit.Pages
{
    public class MainPage
    {
        public void TransitionToMail()
        {
            BrowserManager.Driver.FindElement(By.XPath("//a/parent::div[@class='desk-notif-card__card']")).Click();
        }
        public void ChangeLanguage()
        {
            BrowserManager.Driver.FindElement(By.XPath("//a[@class='home-link i-bem dropdown2__switcher home-link_black_yes']")).Click();
            Wait.ForExist(By.XPath("//a[@id='uniq286']"));
            if (BrowserManager.Driver.FindElement(By.XPath("//a[@class='menu__item menu__item_type_link']/span")).Text != "Eng")
            {
                BrowserManager.Driver.FindElement(By.XPath("//a[@id='uniq286']")).Click();
                CheckWindowsHandels.CheckWindowHandel();
                BrowserManager.Driver.FindElement(By.XPath("//button[@class='button select__button button_theme_normal button_arrow_down button_size_m i-bem button_js_inited']")).Click();
                BrowserManager.Driver.FindElement(By.XPath("//option[contains(text(),'English')]")).Click();
                BrowserManager.Driver.FindElement(By.XPath("//button[@class='button form__save button_theme_action button_size_m i-bem button_js_inited'])")).Click();
            }
            else
            {
                BrowserManager.Driver.FindElement(By.XPath("a[@class='//menu__item menu__item_type_link']/parent::span[contains(text(),'Eng')]")).Click();
            }
        }

        public bool CheckLang()
        {
            return BrowserManager.Driver.FindElement(By.XPath("//a[@class='home-link i-bem dropdown2__switcher home-link_black_yes']")).Text == "Eng";
        }
    }
}
