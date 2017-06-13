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

        public Tab(SeleniumWebdriver seleniumWebdriver)
        {
            this.webDriver = seleniumWebdriver;
        }
    }
}
