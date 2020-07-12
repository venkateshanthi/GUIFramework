using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Framework.Configuration.DirverObjectFactory.Resolver
{
    public interface IDriverFactory
    {
        string Name { get; }

        IWebDriver Resolve(WebBrowserConfiguration webBrowserConfiguration);

        dynamic Setcapabilites(WebBrowserConfiguration webBrowserConfiguration);
    }
}
