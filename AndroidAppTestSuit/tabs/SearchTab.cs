using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.utils;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs
{
    public class SearchTab : Tab
    {
        private By searchField = By.Id("search_text");

        public SearchTab(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }

        public string GetElementText(string element)
        {
            By elementLocator;
            if (element.Equals("Search"))
            {
                elementLocator = searchField;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported field", element));
            }
            
            return webDriver.GetText(elementLocator);
        }
    }
}
