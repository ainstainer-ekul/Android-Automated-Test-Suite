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
            //            //--------- comment  device name/OS version sections for running from VS

            ////            runtests.cmd "Google Nexus 5_4.4" testpath: Feature* Login*
            ////        "Google Nexus 5_4.4"
            ////        "Google Nexus 10_5.0"
            //////      Choose a device name (ex. "Google Nexus 5", "Google Nexus 10")
            // Environment.SetEnvironmentVariable("env.DeviceNameAndOS", "Google Nexus 5_4.4");

            //// Choose full path to app
            Environment.SetEnvironmentVariable("env.AppVersion", "com.soundcloud.android_2017.05.30-beta-674_minAPI16(armeabi,armeabi-v7a,x86)(nodpi)_apkmirror.com.apk");

            string deviceNameAndOS = Environment.GetEnvironmentVariable("env.DeviceNameAndOS").Replace("\"", "");

            Console.WriteLine("|| deviceNameAndOS |  " + deviceNameAndOS);

            Console.WriteLine("|| DeviceName      |  " + deviceNameAndOS.Split('_')[0]);

            Console.WriteLine("|| AndroidVersion  |  " + deviceNameAndOS.Split('_')[1]);

            String appVersion = Environment.GetEnvironmentVariable("env.AppVersion");
            Console.WriteLine("|| AppVersion      |  " + appVersion);

            setUniqueValue(Common.GenerateRandomValue());
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            GetSuite().GetSeleniumWebdriver().ResetApp();
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
