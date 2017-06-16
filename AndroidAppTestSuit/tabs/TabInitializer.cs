using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.tabs.more;
using AndroidAppTestSuit.tabs.popup;
using AndroidAppTestSuit.tabs.webview;
using AndroidAppTestSuit.webdriver;

namespace AndroidAppTestSuit.tabs
{
    public class TabInitializer : Tab
    {
        private SeleniumWebdriver webDriver;
        public TabInitializer(SeleniumWebdriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        public HomeTab GetHomeTab()
        {
            return new HomeTab(webDriver);
        }

        public LoginTab GetLoginTab()
        {
            return new LoginTab(webDriver);
        }

        public SearchTab GetSearchTab()
        {
            return new SearchTab(webDriver);
        }

        public ErrorPopup GetErrorPopup()
        {
            return new ErrorPopup(webDriver);
        }

        public NavTab GetNavTab()
        {
            return new NavTab(webDriver);
        }

        public MoreTab GetMoreTab()
        {
            return new MoreTab(webDriver);
        }

        public YouTab GetYouTab()
        {
            return new YouTab(webDriver);
        }

        public Tab GetBaseTab()
        {
            return new Tab(webDriver);
        }

        public Tab GetOneMoreStepTab()
        {
            return new OneMoreStepTab(webDriver);
        }

        public FacebookWebView GetFacebookWebView()
        {
            return new FacebookWebView(webDriver);
        }
    }
}
