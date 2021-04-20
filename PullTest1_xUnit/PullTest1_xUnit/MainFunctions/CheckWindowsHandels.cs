using System;
using System.Collections.Generic;
using System.Text;

namespace PullTest1_xUnit.MainFunctions
{
    public class CheckWindowsHandels
    {
        static string mainWindowHandle;
        static List<string> WindowHandles;

        public static void CheckWindowHandel()
        {
            mainWindowHandle = BrowserManageSingleton.Driver.CurrentWindowHandle;
            WindowHandles = new List<string>(BrowserManageSingleton.Driver.WindowHandles);
            int i = 0; string ChildWindow = WindowHandles[0];
            while (WindowHandles.Count > i)
            {
                if (mainWindowHandle != WindowHandles[i])
                {
                    BrowserManageSingleton.Driver.SwitchTo().Window(WindowHandles[i]);
                    mainWindowHandle = WindowHandles[i];
                }
                i++;
            }
        }
    }
}
