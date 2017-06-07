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
        [When(@"tap '(.*)' button on \[(.*)] tab")]
        public void WhenTapButtonOnHomeTab(string button, string tab)
        {
            if (tab.Equals("Home"))
            {
                GetSuite().GetTabInit().GetHomeTab().PressButton(button);
            }
            else if (tab.Equals("Login"))
            {
                GetSuite().GetTabInit().GetLoginTab().PressButton(button);
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported tab", tab));
            }
        }
        
        [When(@"fill in a email field with '(.*)' on \[Login] tab")]
        public void WhenFillInAEmailFieldWithOnLoginTab(string email)
        {
            GetSuite().GetTabInit().GetLoginTab().TypeEmail(GetTextFieldValue(email));
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
