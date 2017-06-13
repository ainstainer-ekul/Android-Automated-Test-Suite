using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs
{
    public class NavTab : Tab
    {

        private By moreButtonLocator = By.XPath("//*[@content-desc='More']");

        public NavTab(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }
        
        public void TapNavIcon(string button)
        {
            By elementLocator;
            if (button.Equals("More"))
            {
                elementLocator = moreButtonLocator;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }

            webDriver.Click(elementLocator);
        }
    }
}
