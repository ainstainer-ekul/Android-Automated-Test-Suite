using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.webdriver;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace AndroidAppTestSuit.steps
{
    public class BaseStep
    {

        private static SuiteRunner suiteRunner;
        private static String uniqueValue;
      

        public static SuiteRunner GetSuite()
        {
            if (suiteRunner == null)
            {
                suiteRunner = new SuiteRunner();
            }
            return suiteRunner;
        }

        public String GetTextFieldValue(String value)
        {
            if (value.Contains("@"))
            {
                String[] email = value.Split('@');
                value = GetUniqueValue(email[0]) + "@" + email[1];
            }
            else
            {
                value = GetUniqueValue(value);
            }
            return value;
        }

        public String GetUniqueValue(String value)
        {
            if (value.Contains("pre-setup"))
            {
                value = GetPreSetupValue(value);
            }
            else
            {
                value = value + uniqueValue;
            }
            return value;
        }

        public String GetPreSetupValue(String value)
        {
            return value.Replace("pre-setup", "").Trim();
        }

        public static void setUniqueValue(String value)
        {
            uniqueValue = value;
            System.Console.WriteLine(String.Format("Current unique value: '{0}'", uniqueValue));
        }

        public string TakeScreenshot(IWebDriver driver, string fileName)
        {
            string screenshotFilePath = null;
            try
            {
                string fileNameBase = string.Format("{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    screenshotFilePath = System.IO.Path.Combine(artifactDirectory, fileNameBase + fileName+ ".png");

                    screenshot.SaveAsFile(screenshotFilePath, ImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
            return screenshotFilePath;
        }

        public static Boolean IsNotEmpty(String str)
        {
            return !string.IsNullOrEmpty(str) ? true : false;
        }


        public string GetUniqueUsername(string username)
        {
            if (username.StartsWith("pre-setup"))
            {
                username = GetTextFieldValue(username);
            }
            else
            {
                string[] usernameItems = username.Split(' ');
                username = GetUniqueValue(usernameItems[0]) + " " + GetUniqueValue(usernameItems[1]);
            }
            return username;
        }
    }
}
