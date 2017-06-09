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
//
//            //// Choose a device name (ex. "Google Nexus 5", "Google Nexus 10")
//            Environment.SetEnvironmentVariable("env.DeviceName", "Google Nexus 5");
//            //
//            //// Choose a android OS version (ex. "4.4", "5.0")
//            Environment.SetEnvironmentVariable("env.AndroidVersion", "4.4");

            //// Choose full path to app
            Environment.SetEnvironmentVariable("env.AppVersion", "com.soundcloud.android_2017.05.30-beta-674_minAPI16(armeabi,armeabi-v7a,x86)(nodpi)_apkmirror.com.apk");

            String deviceName = Environment.GetEnvironmentVariable("env.DeviceName");
            Console.WriteLine("|| DeviceName     |  " + deviceName);

            String androidVersion = Environment.GetEnvironmentVariable("env.AndroidVersion");
            Console.WriteLine("|| AndroidVersion |  " + androidVersion);

            String appVersion = Environment.GetEnvironmentVariable("env.AppVersion");
            Console.WriteLine("|| AppVersion     |  " + appVersion);

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
