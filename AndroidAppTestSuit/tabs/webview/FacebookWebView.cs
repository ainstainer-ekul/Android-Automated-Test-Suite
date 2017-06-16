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

        public FacebookWebView(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
            ((AndroidDriver<IWebElement>) webDriver.GetDriver()).Context = webViewContextName;

        }

        public void TypeEmail(string email)
        {
            var contexts = ((AndroidDriver<IWebElement>) webDriver.GetDriver()).Contexts;


            
//
//            Console.WriteLine("||| Length " + ((AndroidDriver<IWebElement>)webDriver.GetDriver()).Context.Length);
//            Console.WriteLine("||| cvContext " + cvContext);

        }

        public void TypePassword(string password)
        {
           // webDriver.ClearAndType(passwordField, password);
        }
    }
}
