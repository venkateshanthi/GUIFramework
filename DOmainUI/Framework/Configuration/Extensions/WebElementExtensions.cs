using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Framework.Configuration.Extensions
{
    public static class WebElementExtensions
    {
        public static void EnterText(this IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        public static void SelectOptionByIndexfromList(this IWebElement element, int index)
        {
            element.Click();
            IList<IWebElement> listoptions = element.FindElements(By.CssSelector("div>div>ul:nth-child(2)>li"));
            if (listoptions.Count > 0)
                listoptions[index - 1].Click();
            else
                Assert.Fail("Element is not present");
        }


    }
}
