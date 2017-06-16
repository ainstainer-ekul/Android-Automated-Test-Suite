using System;
using AndroidAppTestSuit.tabs;
using AndroidAppTestSuit.utils;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AndroidAppTestSuit.steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
       
        [When(@"fill in a email field with '(.*)' on \[Login] tab")]
        public void WhenFillInAEmailFieldWithOnLoginTab(string email)
        {
            GetSuite().GetTabInit().GetLoginTab().TypeEmail(GetTextFieldValue(email));
        }

        [When(@"fill in a email field with '(.*)' on \[Facebook] tab")]
        public void WhenFillInAEmailFieldWithOnFacebookTab(string email)
        {
            GetSuite().GetTabInit().GetFacebookWebView().TypeEmail(GetTextFieldValue(email));
        }

        [When(@"fill in a password field with '(.*)' on \[Facebook] tab")]
        public void WhenFillInAPasswordFieldWithOnFacebookTab(string password)
        {
            GetSuite().GetTabInit().GetFacebookWebView().TypePassword(password);
        }

        [When(@"fill in a password field with '(.*)' on \[Login] tab")]
        public void WhenFillInAPasswordFieldWithOnLoginTab(string password)
        {
            GetSuite().GetTabInit().GetLoginTab().TypePassword(password);
        }

        [Then(@"should see '(.*)' placeholder text '(.*)' field on \[Search] tab")]
        public void ThenShouldSeePlacehoderOnSearchTab(string placeHoldertext, string field)
        {
            SearchTab searchButton = GetSuite().GetTabInit().GetSearchTab();

            Assert.That(searchButton.GetElementText(field),
                Is.EqualTo(placeHoldertext),
                String.Format("'{0}' - incorrect placeholder text ", searchButton.GetElementText(field)));
        }
    }
}
