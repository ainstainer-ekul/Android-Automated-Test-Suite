using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.tabs;
using AndroidAppTestSuit.tabs.popup;
using AndroidAppTestSuit.utils;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace AndroidAppTestSuit.steps
{
    [Binding]
    public class CommonSteps : BaseStep
    {
        [When(@"tap '(.*)' (?:button|image) on \[(.*)] tab")]
        public void WhenTapButtonOnHomeTab(string button, string tab)
        {
            if (tab.Equals("Home"))
            {
                GetSuite().GetTabInit().GetHomeTab().TapButton(button);
            }
            else if (tab.Equals("Login"))
            {
                GetSuite().GetTabInit().GetLoginTab().TapButton(button);
            }
            else if (tab.Equals("More"))
            {
                GetSuite().GetTabInit().GetMoreTab().TapButton(button);
            }
            else if (tab.Equals("You"))
            {
                GetSuite().GetTabInit().GetYouTab().TapButton(button);
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported tab", tab));
            }
        }

        [When(@"tap '(.*)' button on navigation bar")]
        public void WhenTapButtonOnNavigationBar(string button)
        {
            GetSuite().GetTabInit().GetNavTab().TapNavIcon(button);
        }

        [Then(@"should see an error popup with a following text:")]
        public void ThenShouldSeeAnErrorPopupWithAFollowingText(string multilineText)
        {
            ErrorPopup errorPopup = GetSuite().GetTabInit().GetErrorPopup();

            Assert.That(errorPopup.GetMessageText(),
                Is.EqualTo(multilineText),
                String.Format("'{0}' - wrong error text", errorPopup.GetMessageText()));
        }

        [Then(@"should see '(.*)' toast")]
        public void ThenShouldSeePopup(string toastMessage)
        {
            Common.Pause(1000);
          
            string imagePath = TakeScreenshot(GetSuite().GetSeleniumWebdriver().GetDriver(), "_screenshot_with_toast_message");

            Assert.That(Common.GetTextFromImage(imagePath),
               Is.StringContaining(toastMessage),
               String.Format("'{0}' - text is absent on the screen", toastMessage));
        }
    }
}
