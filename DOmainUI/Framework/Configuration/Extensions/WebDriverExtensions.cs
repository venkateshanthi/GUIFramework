using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Framework.Configuration.Extensions
{
    public static class WebDriverExtensions
    {
        public static int timeout = 59;
        /// <summary>
        /// Method will hold the process till page has been uploaded 
        /// </summary>
        /// <param name="driver">driver you want to wait till page get load</param>
        public static void WaitToLoadPage(this IWebDriver driver)
        {
            ///Test
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        /// <summary>
        /// This function will wait for element to be exist and look for element every interval time 
        /// </summary>
        /// <param name="driver">IWebDriver</param>
        /// <param name="locator">By</param>
        public static void WaitForElementToExist(this IWebDriver driver, By locator)
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            IWebElement ele = waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            Assert.IsTrue(ele.Displayed);
        }
        /// <summary>
        /// This function will wait for element to exist
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element">IWebElement</param>
        public static void WaitForElementToExist(this IWebDriver driver, IWebElement element)
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            bool result = waitForElement.Until(ele => element.Displayed);
            Assert.IsTrue(result);
        }
        /// <summary>
        /// This method wait for element and click 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void WaitToElementExistandClick(this IWebDriver driver, IWebElement element)
        {
            WaitForElementToExist(driver, element);
            element.Click();
        }
        public static void WaitToElementExistandClick(this IWebDriver driver, By locator)
        {
            WaitForElementToExist(driver, locator);
            driver.FindElement(locator).Click();
        }
    }
}
