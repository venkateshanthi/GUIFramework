using DOmainUI.Framework.PageObjectFactory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        [FindsBy(How.Name, "q")]
        public IWebElement Googlepage { get; set; }

        public void OpenGooglePage()
        {
            Driver.Navigate().GoToUrl("https://www.google.co.uk/");
        }
    }

    
}
