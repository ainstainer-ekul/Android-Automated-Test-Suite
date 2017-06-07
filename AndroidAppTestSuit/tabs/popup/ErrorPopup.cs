using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs.popup
{
    public class ErrorPopup : Tab
    {
        private By messageBox = By.Id("message");

        public ErrorPopup(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }

        public string GetMessageText()
        {
            return webDriver.GetText(messageBox);
        }
    }
}
