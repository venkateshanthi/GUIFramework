using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DOmainUI.Hooks
{
    [Binding]
    public class ConfigurationHooks

    {

        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;



        public ConfigurationHooks(IObjectContainer objectContainer)

        {

            _objectContainer = objectContainer;

        }



        [BeforeTestRun]

        public static void SetConfiguration(IObjectContainer objectContainer)

        {

            var configuration = new ConfigurationBuilder()

               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)

               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configurationroot = configuration.Build();



            objectContainer.RegisterInstanceAs<EnvironmentConfiguration>(configurationroot.GetSection("EnvironmentConfiguration").Get<EnvironmentConfiguration>());

            objectContainer.RegisterInstanceAs<WebBrowserConfiguration>(configurationroot.GetSection("WebBrowserConfiguration").Get<WebBrowserConfiguration>());

            objectContainer.RegisterInstanceAs<AzureSearchConfiguration>(configurationroot.GetSection("AzureSearchConfiguration").Get<AzureSearchConfiguration>());

            var internalApiConfig = configurationroot.GetSection("InternalApi").Get<InternalApiConfiguration>();

            var trustingHandlerBuilder = new TrustingHandlerBuilder();

            var httpClient = new HttpClient(trustingHandlerBuilder.GetTrustingHandler()) { BaseAddress = new Uri(internalApiConfig.BaseUri) };

            var ordersCommandService =

                new OrdersCommandService(httpClient, new TokenManager(internalApiConfig.TokenUri, internalApiConfig.ClientName, internalApiConfig.ClientSecret));

            objectContainer.RegisterInstanceAs(ordersCommandService, typeof(IOrdersCommandService));

        }



        [BeforeScenario(Order = 0)]

        public void BeforeScenario(WebBrowserConfiguration webBrowserConfiguration)

        {

            _driver = new DriverFactory(webBrowserConfiguration).Create();

            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

        }



        [AfterScenario(Order = 2)]

        public void AfterScenario()

        {

            _driver.Quit();

            var driver = _objectContainer.Resolve<IWebDriver>();

            driver.Dispose();

        }



        [AfterTestRun]

        private static void AfterTestRunResolveConfiguration(IObjectContainer objectContainer)

        {

            var envConfig = objectContainer.Resolve<EnvironmentConfiguration>();

            var browserConfig = objectContainer.Resolve<WebBrowserConfiguration>();

            var azureserachConfig = objectContainer.Resolve<AzureSearchConfiguration>();

            var commandServiceConfig = objectContainer.Resolve(typeof(IOrdersCommandService), "");

        }

    }

}
