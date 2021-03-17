using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit.Pages
{
    public class MainPage
    {
        public static void TransitionToMail()
        {
            BrowserManager.Driver.FindElement(By.XPath("//a/parent::div[@class='desk-notif-card__card']")).Click();
        }
    }
}
