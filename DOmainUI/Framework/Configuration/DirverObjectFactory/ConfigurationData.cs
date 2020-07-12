using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Framework.Configuration.DirverObjectFactory
{
    public class WebBrowserConfiguration
    {
        public string BrowserType { get; set; }
        public double Timeout { get; set; }

        public bool HeadlessMode { get; set; }
        public string Browsername { get; set; }
        public string Platform { get; set; }
        public string RemoteUri { get; set; }
    }

    public class EnvironmentConfiguration
    {
        public string BaseURL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TestResultFolder { get; set; }
    }

    public class InternalApiConfiguration
    {
        public string TokenUri { get; set; }
        public string BaseUri { get; set; }
        public string ClientName { get; set; }
        public string  ClientSecret { get; set; }
    }
}
