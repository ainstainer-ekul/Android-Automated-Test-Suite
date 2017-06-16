using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs
{
    public class OneMoreStepTab : Tab
    {
        private By continueButton = By.Id("btn_accept_terms");
         
        public OneMoreStepTab(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }

        public void TapNavIcon(string button)
        {
            By elementLocator;
            if (button.Equals("Continue"))
            {
                elementLocator = continueButton;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }

            webDriver.Click(elementLocator);
        }
    }
}
