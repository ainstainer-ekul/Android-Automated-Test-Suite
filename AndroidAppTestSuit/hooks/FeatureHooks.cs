using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.steps;
using AndroidAppTestSuit.utils;
using TechTalk.SpecFlow;

namespace AndroidAppTestSuit.hooks
{
    [Binding]
    public sealed class FeatureHooks : BaseStep
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //--------- comment server/broser sections for running from VS, 

            //// Choose a server (ex. "dev1", "dev2", "staging")
            Environment.SetEnvironmentVariable("env.Server", "staging");
            //
            //// Choose a browser (ex. "Firefox", "Chrome", "MobileChrome", "RemoteChrome", "AndroidAppiumChrome", "IosApp", "ANDROIDAPP")
            Environment.SetEnvironmentVariable("env.Browser", "AndroidApp");


            String server = Environment.GetEnvironmentVariable("env.Server");
            Console.WriteLine("|| server  |  " + server);

            String browser = Environment.GetEnvironmentVariable("env.Browser");
            Console.WriteLine("|| browser |  " + browser);

            setUniqueValue(Common.GenerateRandomValue());
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
  
        }

        [AfterScenario]
        public void AfterScenario()
        {           
            if (ScenarioContext.Current.TestError != null)
            {
                TakeScreenshot(GetSuite().GetSeleniumWebdriver().GetDriver());
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            GetSuite().GetSeleniumWebdriver().Quit();
        }
    }
}
