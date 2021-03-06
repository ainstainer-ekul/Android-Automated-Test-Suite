﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.utils;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidAppTestSuit.tabs
{
    public class Tab
    {
        private string appContextName = "NATIVE_APP";

        private By okButton = By.Id("btn_accept_terms");
        
        public SeleniumWebdriver webDriver;

        public Tab(SeleniumWebdriver seleniumWebdriver)
        {
            this.webDriver = seleniumWebdriver;
        }

        public void TapButton(String button)
        {
            By buttonLocator;
            if (button.Equals("Ok"))
            {
                ((AndroidDriver<IWebElement>)webDriver.GetDriver()).Context = appContextName;
  
                buttonLocator = okButton;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }
            webDriver.Click(buttonLocator);
        }
    }
}
