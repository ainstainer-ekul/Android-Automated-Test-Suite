using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs
{
    public class Tab
    {
        private By okButton = By.Id("button1");

        public SeleniumWebdriver webDriver;

        public Tab(SeleniumWebdriver seleniumWebdriver)
        {
            this.webDriver = seleniumWebdriver;
        }


        public void TapButton(String button)
        {
            By buttonLocator;
            if (button.Equals("Ok"))
            {
                buttonLocator = okButton;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }
            webDriver.Click(buttonLocator);
        }
    }
}
