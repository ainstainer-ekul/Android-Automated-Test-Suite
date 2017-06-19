using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidAppTestSuit.tabs.webview
{
    public class FacebookWebView : Tab
    {
        private string webViewContextName = "WEBVIEW_com.soundcloud.android";
        private By emailField = By.XPath("//*[@name='email']");
        private By passwordField = By.XPath("//*[@name='pass']");
        private By loginButton = By.XPath("//*[@name='login']");

        public FacebookWebView(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
            ((AndroidDriver<IWebElement>) webDriver.GetDriver()).Context = webViewContextName;
        }

        public void TypeEmail(string email)
        {
            webDriver.ClearAndType(emailField, email);
        }

        public void TypePassword(string password)
        {
            webDriver.ClearAndType(passwordField, password);
        }

        public void TapButton(String button)
        {
            By buttonLocator;
            if (button.Equals("Log In"))
            {
                buttonLocator = loginButton;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }
            webDriver.Click(buttonLocator);
        }
    }
}
