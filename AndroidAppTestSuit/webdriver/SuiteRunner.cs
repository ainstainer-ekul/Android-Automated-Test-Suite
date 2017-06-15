using AndroidAppTestSuit.tabs;

namespace AndroidAppTestSuit.webdriver
{
    public class SuiteRunner
    {
        private SeleniumWebdriver webDriver;
        private TabInitializer pageInitializer;

        public SeleniumWebdriver GetSeleniumWebdriver()
        {
            if (webDriver == null)
            {
                webDriver = new SeleniumWebdriver();
            }
            return webDriver;
        }

        public TabInitializer GetTabInit()
        {
            if (pageInitializer == null)
            {
                pageInitializer = new TabInitializer(GetSeleniumWebdriver());
            }
            return pageInitializer;
        }
    }
}
