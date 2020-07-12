using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace DOmainUI.Framework.Configuration.DirverObjectFactory.Resolver
{
    public class EdgeResolver : IDriverFactory
    {
        public string Name { get { return "edge"; } }

        public IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration)
        {
            dynamic option = Setcapabilites(webBrowserConfiguration);
            EdgeDriverService service = EdgeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            System.Environment.SetEnvironmentVariable("webdriver.edge.driver", Assembly.GetEntryAssembly().Location);
            RemoteWebDriver driver = new EdgeDriver(service, option);
            driver.Manage().Window.Maximize();
            return driver;

        }

        public dynamic Setcapabilites(WebBrowserConfiguration webBrowserConfiguration)
        {
            EdgeOptions option = new EdgeOptions();
            option.PageLoadStrategy = PageLoadStrategy.Eager;
            return option;
        }
    }
}
