using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DOmainUI.Framework.PageObjectFactory
{
    public interface IPageObjectMemberDecorator
    {
        object Decorate(MemberInfo member, IElementLocator locator);
    }
}
