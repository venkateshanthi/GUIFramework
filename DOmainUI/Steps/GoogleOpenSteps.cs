using DOmainUI.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DOmainUI.Steps
{
    [Binding]
    public class GoogleOpenSteps
    {
        private LoginPage loginPage;

        public GoogleOpenSteps(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }

        [Given(@"I have open the gmail account")]
        public void GivenIHaveOpenTheGmailAccount()
        {
            loginPage.OpenGooglePage();
        }

    }
}
