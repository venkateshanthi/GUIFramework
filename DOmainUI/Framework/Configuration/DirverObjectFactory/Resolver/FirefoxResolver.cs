using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DOmainUI.Framework.Configuration.DirverObjectFactory.Resolver
{
    public class FirefoxResolver : IDriverFactory
    {
        public string Name { get {return "firefox"; } }

        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            dynamic option = Setcapabilites(webBrowserConfiguration);
            IWebDriver driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public dynamic Setcapabilites(WebBrowserConfiguration webBrowserConfiguration)
        {
            FirefoxOptions option = new FirefoxOptions();
            option.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            return option;
        }
    }
}
