using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;

namespace AndroidAppTestSuit.tabs
{
    public class LoginTab : Tab
    {
        private By doneButton = By.Id("btn_login");
        private By emailField = By.Id("auto_txt_email_address");
        private By passwordField = By.Id("txt_password");

        public LoginTab(SeleniumWebdriver seleniumWebdriver) : base(seleniumWebdriver)
        {
        }

        public void PressButton(String button)
        {
            By buttonLocator;
            if (button.Equals("Done"))
            {
                buttonLocator = doneButton;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported button", button));
            }
            webDriver.Click(buttonLocator);
        }

        public void TypeEmail(string email)
        {
            webDriver.ClearAndType(emailField, email);
        }

        public void TypePassword(string password)
        {
            webDriver.ClearAndType(passwordField, password);
        }

        public string GetEmailPlaceHolder()
        {
            return webDriver.FindElement(emailField).Text;
        }
    }
}
