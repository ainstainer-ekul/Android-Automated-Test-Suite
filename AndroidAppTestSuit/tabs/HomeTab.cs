using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs
{
    public class HomeTab : Tab
    {
        private By signInButton = By.Id("btn_login");

        public HomeTab(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }

        public void TapButton(String button)
        {
            By buttonLocator;
            if (button.Equals("Sign In"))
            {
                buttonLocator = signInButton;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }
            webDriver.Click(buttonLocator);

        }
    }
}
