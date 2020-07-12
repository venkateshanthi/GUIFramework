using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Framework.Configuration.DirverObjectFactory.Resolver
{
   public class DriverFactory
    {
        private string Btype = string.Empty;
        public WebBrowserConfiguration WebBrowserConfiguration;

        public static List<IDriverFactory> DriverFactoryList = new List<IDriverFactory>
        {
            new ChromeResolver(),
            new FirefoxResolver(),
           // new InternetExplorerDriver(),
            new EdgeResolver(),
           // new RemoteWebDriver()
        };

        public DriverFactory(WebBrowserConfiguration webBrowserConfiguration)
        {
            WebBrowserConfiguration = webBrowserConfiguration;
            Btype = webBrowserConfiguration.BrowserType;
        }

        public IWebDriver Create()
        {
            IWebDriver driver;
            driver = DriverFactoryList.Find(item => item.Name == Btype).Resolve(WebBrowserConfiguration);
            return driver;
        }
    }
}
