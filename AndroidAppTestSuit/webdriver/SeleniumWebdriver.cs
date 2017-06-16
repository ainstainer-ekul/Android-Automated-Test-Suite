using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace AndroidAppTestSuit.webdriver
{
    public class SeleniumWebdriver : IWebDriver, ISearchContext
    {
        private IWebDriver driver;
        private int PAGE_LOAD_TIMEOUT_SEC = 60;
        private int ELEMENT_LOAD_TIMEOUT_SEC = 30;
        private WebDriverWait driverWait;

        public SeleniumWebdriver()
        {
            DesiredCapabilities androidAppiumAppCapability = new DesiredCapabilities();

            string deviceNameAndOS = Environment.GetEnvironmentVariable("env.DeviceNameAndOS");
            String deviceName = deviceNameAndOS.Replace("\"", "");

            androidAppiumAppCapability.SetCapability("deviceName", deviceName.Split('_')[0]);
            androidAppiumAppCapability.SetCapability("platformVersion", deviceName.Split('_')[1]);

            androidAppiumAppCapability.SetCapability("fullReset", true);

            string appPath = Common.GetFilePathForRunViaSpecrun(Common.GetProjectRootDir()) + Path.DirectorySeparatorChar + "androidApp"
                + Path.DirectorySeparatorChar + Environment.GetEnvironmentVariable("env.AppVersion");

            androidAppiumAppCapability.SetCapability("app", appPath);
            androidAppiumAppCapability.SetCapability("platformName", "Android");
            androidAppiumAppCapability.SetCapability("appActivity", @"com.soundcloud.android.main.LauncherActivity");
            androidAppiumAppCapability.SetCapability("appPackage", @"com.soundcloud.android");

            Console.WriteLine("| deviceName || " + deviceName.Split('_')[2] );

            driver = new AndroidDriver<IWebElement>(new Uri(deviceName.Split('_')[2] + "/wd/hub"), androidAppiumAppCapability, TimeSpan.FromSeconds(PAGE_LOAD_TIMEOUT_SEC));

            this.driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(ELEMENT_LOAD_TIMEOUT_SEC));
        }

        public string CurrentWindowHandle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PageSource
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Title
        {
            get
            {
                return driver.Title;
            }
        }

        public string Url
        {
            get
            {
                return driver.Url;
            }

            set
            {
                driver.Url = Url;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get { return driver.WindowHandles; }
        }

        public void Close()
        {
            driver.Close();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return driver.Navigate();
        }

        public void Quit()
        {
            driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public void GoToUrl(string url)
        {
            Navigate().GoToUrl(url);
        }

        public void ClearAndType(By locator, String value)
        {
            IWebElement element = WaitUntilIsNotVisible(locator);

            element.Click();
            element.Clear();
            element.SendKeys(value);
        }

        public void Click(By locator)
        {
            WaitUntilIsNotVisible(locator);
            IWebElement element = driver.FindElement(locator);
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                Common.Pause(1000);
                element.Click();
            }
        }

        public String GetText(By locator)
        {
            WaitUntilIsNotVisible(locator);
            return driver.FindElement(locator).Text;
        }

        public IWebElement WaitUntilIsNotVisible(By locator)
        {
            OpenQA.Selenium.Support.UI.IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ELEMENT_LOAD_TIMEOUT_SEC));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void WaitUntilIsVisible(By locator)
        {
            OpenQA.Selenium.Support.UI.IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ELEMENT_LOAD_TIMEOUT_SEC));
            driverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public Boolean IsElementPresent(By by)
        {
            return this.FindElements(by).Count > 0;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void InteractWithCheckBox(By by, String action)
        {
            if (action.Equals("checked"))
            {
                Check(by);
            }
            else if (action.Equals("unchecked"))
            {
                UnCheck(by);
            }
            else
            {
                throw new ArgumentException(String.Format(
                        "{0}' is not supported, please use 'checked' or 'unchecked' options", action));
            }
        }

        public void Check(By by)
        {
            IWebElement element = driver.FindElement(by);

            if (!element.Selected)
            {
                element.Click();
            }
        }

        public void UnCheck(By by)
        {
            IWebElement element = driver.FindElement(by);
            if (element.Selected)
            {
                element.Click();
            }
        }

        public void Hover(By by)
        {
            IWebElement webElement = driver.FindElement(by);

            String javaScript = "var evObj = document.createEvent('MouseEvents');" +
            "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
            "arguments[0].dispatchEvent(evObj);";

            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, webElement);
        }

        public void SelectFromDropDownList(By by, String item)
        {
            ScrollToElement(by);
            try
            {
                new SelectElement(driver.FindElement(by)).SelectByText(item);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Unable to select '{0}' in '{1}' dropdown. Full message error: {2}", item, by, e.Message));
            }
        }

        public IJavaScriptExecutor GetJSExecutor()
        {
            return driver as IJavaScriptExecutor;
        }

        public void ScrollToTop()
        {
            var javaScriptExecutor = GetJSExecutor();
            javaScriptExecutor.ExecuteScript("window.scrollTo(0, 0);");
        }

        public void VerticalScroll(string direction, string screenHeightNumber)
        {
            var javaScriptExecutor = GetJSExecutor();
            int screenHeight = Convert.ToInt32(javaScriptExecutor.ExecuteScript("return window.innerHeight"));
            screenHeight *= Convert.ToInt32(screenHeightNumber);
            javaScriptExecutor.ExecuteScript(string.Format("window.scrollBy(0, {0});", direction + screenHeight));
        }

        public void ScrollToBottom()
        {
            var javaScriptExecutor = GetJSExecutor();
            javaScriptExecutor.ExecuteScript("$(window).scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollToElement(By by)
        {
            var elem = driver.FindElement(by);
            var javaScriptExecutor = GetJSExecutor();
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", elem);
        }

        public void ClickUsingJS(By by)
        {
            IWebElement element = driver.FindElement(by);
            var javaScriptExecutor = GetJSExecutor();
            javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public void ClickUsingJS(IWebElement iWebElement)
        {
            var javaScriptExecutor = GetJSExecutor();
            javaScriptExecutor.ExecuteScript("arguments[0].click();", iWebElement);
        }

        public void UploadFile(By uploadButton, string pathToFile)
        {
            driver.FindElement(uploadButton).SendKeys(pathToFile);
            for (int i = 0; i < 20; i++)
            {
                if (driver.FindElement(uploadButton).Enabled)
                {
                    return;
                }
                else
                {
                    Common.Pause(1000);
                }
            }
        }

        public string GetValue(By by)
        {
            return driver.FindElement(by).GetAttribute("value");
        }

        public Actions GetActionsClass()
        {
            return new Actions(driver);
        }

        /* 
         * Check if an element displayed with expected condition. Allows to avoid the synchronization time issues
         * 
         */
        public bool IsElementDisplayed(string condition, By locator)
        {
            bool visibilityState;
            if (Common.IsShould(condition))
            {
                WaitUntilIsNotVisible(locator);
                visibilityState = IsElementPresent(locator);
            }
            else
            {
                visibilityState = IsElementPresent(locator);
            }
            return visibilityState;
        }

        public void PressKey(string key)
        {
            By bodyLocator = By.XPath("//body");
            driver.FindElement(bodyLocator).SendKeys(GetKeysByName(key));
        }

        private string GetKeysByName(string keyName)
        {
            if (keyName.Equals("Enter"))
            {
                return Keys.Enter;
            }
            else
            {
                throw new Exception(string.Format("'{0}' - unsupported key name", keyName));
            }
        }

        public void Tap(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void ResetApp()
        {
            ((AndroidDriver<IWebElement>)driver).ResetApp();
        }
    }
}
