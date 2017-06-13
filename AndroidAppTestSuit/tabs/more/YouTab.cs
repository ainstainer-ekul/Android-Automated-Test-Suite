using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs.more
{
    public class YouTab : NavTab
    {
        private By avatarIcon = By.Id("image");

        public YouTab(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }

        public void TapButton(string element)
        {
            By buttonLocator;
            if (element.Equals("Avatar"))
            {
                buttonLocator = avatarIcon;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported field", element));
            }

            webDriver.Click(buttonLocator);
        }
    }
}
