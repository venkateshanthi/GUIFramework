using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DOmainUI.Framework.PageObjectFactory
{
    public sealed class PageFactory

    {

        private PageFactory()

        {

        }



        /// <summary>

        /// Initializes the elements in the Page Object.

        /// </summary>

        /// <param name="driver">The driver used to find elements on the page.</param>

        /// <param name="page">The Page Object to be populated with elements.</param>

        /// <exception cref="ArgumentException">

        /// thrown if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type

        /// <see cref="IWebElement"/> or IList{IWebElement}.

        /// </exception>

        public static void InitElements(ISearchContext driver, object page)

        {

            InitElements(page, new DefaultElementLocator(driver), new DefaultPageObjectMemberDecorator());

        }



        /// <summary>

        /// Initializes the elements in the Page Object.

        /// </summary>

        /// <param name="page">The Page Object to be populated with elements.</param>

        /// <param name="locator">The <see cref="IElementLocator"/> implementation that

        /// determines how elements are located.</param>

        /// <param name="decorator">The <see cref="IPageObjectMemberDecorator"/> implementation that

        /// determines how Page Object members representing elements are discovered and populated.</param>

        /// <exception cref="ArgumentException">

        /// thrown if a field or property decorated with the <see cref="FindsByAttribute"/> is not of type

        /// <see cref="IWebElement"/> or IList{IWebElement}.

        /// </exception>

        public static void InitElements(object page, IElementLocator locator, IPageObjectMemberDecorator decorator)

        {

            if (page == null)

            {

                throw new ArgumentNullException("page", "page cannot be null");

            }



            if (locator == null)

            {

                throw new ArgumentNullException("locator", "locator cannot be null");

            }



            if (decorator == null)

            {

                throw new ArgumentNullException("locator", "decorator cannot be null");

            }



            if (locator.SearchContext == null)

            {

                throw new ArgumentException("The SearchContext of the locator object cannot be null", "locator");

            }



            const BindingFlags PublicBindingOptions = BindingFlags.Instance | BindingFlags.Public;

            const BindingFlags NonPublicBindingOptions = BindingFlags.Instance | BindingFlags.NonPublic;



            // Get a list of all of the fields and properties (public and non-public [private, protected, etc.])

            // in the passed-in page object. Note that we walk the inheritance tree to get superclass members.

            var type = page.GetType();

            var members = new List<MemberInfo>();

            members.AddRange(type.GetFields(PublicBindingOptions));

            members.AddRange(type.GetProperties(PublicBindingOptions));

            while (type != null)

            {

                members.AddRange(type.GetFields(NonPublicBindingOptions));

                members.AddRange(type.GetProperties(NonPublicBindingOptions));

                type = type.BaseType;

            }



            foreach (var member in members)

            {

                // Examine each member, and if the decorator returns a non-null object,

                // set the value of that member to the decorated object.

                object decoratedValue = decorator.Decorate(member, locator);

                if (decoratedValue == null)

                {

                    continue;

                }



                var field = member as FieldInfo;

                var property = member as PropertyInfo;

                if (field != null)

                {

                    field.SetValue(page, decoratedValue);

                }

                else if (property != null)

                {

                    property.SetValue(page, decoratedValue, null);

                }

            }

        }

    }

}