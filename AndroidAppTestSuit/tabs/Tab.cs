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
        public SeleniumWebdriver webDriver;

//        protected By progressSpinner = By.CssSelector(".progress");
//        protected By iframe = By.XPath("//iframe");
//        protected By loggedInUsername = By.XPath("//*[@size='32']/..");
//
//        protected const string iFrameUrl = "?iframeView=false";

        public Tab(SeleniumWebdriver seleniumWebdriver)
        {
            this.webDriver = seleniumWebdriver;
        }
    }
}
