using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace DOmainUI.Framework.Configuration.DirverObjectFactory.Resolver
{
    public class ChromeResolver : IDriverFactory
    {
        public string Name { get { return "chrome"; } }

        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            dynamic option = Setcapabilites(webBrowserConfiguration);
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(Directory.GetCurrentDirectory());
            IWebDriver driver = new ChromeDriver(driverService, option);
            return driver;
        }

        public dynamic Setcapabilites(WebBrowserConfiguration webBrowserConfiguration)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-Maximized");
            option.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
            if (webBrowserConfiguration.HeadlessMode)
                option.AddArgument("headless");
            return option;
        }
    }
}
