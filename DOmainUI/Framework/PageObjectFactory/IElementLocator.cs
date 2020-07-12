using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOmainUI.Framework.PageObjectFactory
{
    public interface IElementLocator
    {
        ISearchContext SearchContext { get; }
        IWebElement LocateElement(IEnumerable<By> bys);
        IList<IWebElement> LocateElements(IEnumerable<By> bys);
    }
}
