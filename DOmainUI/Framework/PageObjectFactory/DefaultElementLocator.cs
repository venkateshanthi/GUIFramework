using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace DOmainUI.Framework.PageObjectFactory
{
    public class DefaultElementLocator : IElementLocator
    {
        private ISearchContext searchContext;
        public DefaultElementLocator(ISearchContext searchContext)
        {
            this.searchContext = searchContext;
        }

        public ISearchContext SearchContext
        {
            get { return this.searchContext; }
        }

        public IWebElement LocateElement(IEnumerable<By> bys)
        {
            if (bys == null)
            {
                throw new ArgumentNullException("bys", "List of criteria may not be null");
            }
            string errorString = null;
            foreach(var by in bys)
            {
                try
                {
                    return this.searchContext.FindElement(by);
                }
                catch (NoSuchElementException)
                {
                    errorString = (errorString == null ? "could not find element by: " : errorString + ", or: ") + by;
                }
            }
            throw new NoSuchElementException(errorString);
        }

        public IList<IWebElement> LocateElements(IEnumerable<By> bys)
        {
            if(bys == null)
            {
                throw new ArgumentNullException("bys", "List of criteria may not be null");
            }

            List<IWebElement> collection = new List<IWebElement>();
            foreach(var by in bys)
            {
                IList<IWebElement> list = this.searchContext.FindElements(by);
                collection.AddRange(list);
            }
            return collection.AsReadOnly();
        }
    }
}
