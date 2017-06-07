using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidAppTestSuit.tabs.popup;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AndroidAppTestSuit.steps
{
    [Binding]
    public class CommonSteps : BaseStep
    {
        [Then(@"should see an error popup with a following text:")]
        public void ThenShouldSeeAnErrorPopupWithAFollowingText(string multilineText)
        {
            ErrorPopup errorPopup = GetSuite().GetTabInit().GetErrorPopup();

            Assert.That(errorPopup.GetMessageText(),
               Is.EqualTo(multilineText),
               String.Format("'{0}' - wrong error text", errorPopup.GetMessageText()));
        }
    }
}
