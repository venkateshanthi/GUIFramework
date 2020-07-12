using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DOmainUI.Framework.PageObjectFactory
{
    public class WebElementListProxy<T> : DispatchProxy

    {

        private Type classtoProxy;

        private IElementLocator locator;

        protected IEnumerable<By> bys;

        private List<IWebElement> collection = null;



        /// <summary>

        /// Gets the list of IWebElement objects this proxy represents, returning a cached one if requested.

        /// </summary>

        private List<IWebElement> ElementList

        {

            get

            {

                if (this.collection == null)

                {

                    this.collection = new List<IWebElement>();

                    this.collection.AddRange(this.locator.LocateElements(this.bys));

                }



                return this.collection;

            }

        }



        /// <summary>

        /// Creates an object used to proxy calls to properties and methods of an <see cref="IWebElement"/> object.

        /// </summary>

        /// <param name="classToProxy">The <see cref="Type"/> of object for which to create a proxy.</param>

        /// <param name="locator">The <see cref="IElementLocator"/> implementation that

        /// determines how elements are located.</param>

        /// <param name="bys">The list of methods by which to search for the elements.</param>

        /// <param name="cacheLookups"><see langword="true"/> to cache the lookup to the element; otherwise, <see langword="false"/>.</param>

        /// <returns>An object used to proxy calls to properties and methods of the list of <see cref="IWebElement"/> objects.</returns>

        public static T CreateProxy(Type classToProxy, IElementLocator locator, IEnumerable<By> bys)

        {

            object proxy = Create<T, WebElementListProxy<T>>();

            ((WebElementListProxy<T>)proxy).SetParamateres(classToProxy, locator, bys);

            return (T)proxy;

        }



        /// <summary>

        /// this Method set parameters of proxy objects

        /// </summary>

        /// <param name="aclassToProxy"></param>

        /// <param name="alocator"></param>

        /// <param name="abys"></param>

        public void SetParamateres(Type aclassToProxy, IElementLocator alocator, IEnumerable<By> abys)

        {

            classtoProxy = aclassToProxy;

            locator = alocator;

            bys = abys;

        }



        /// <summary>

        /// Invokes the method that is specified in the provided <see cref=""/> on the

        /// object that is represented by the current instance.

        /// </summary>

        /// <param name="msg">An <see cref=""/> that contains a dictionary of

        /// information about the method call. </param>

        /// <returns>The message returned by the invoked method, containing the return value and any

        /// out or ref parameters.</returns>

        protected override object Invoke(MethodInfo msg, object[] args)

        {

            var elements = this.ElementList;

            if (typeof(IList<IWebElement>).Equals(msg.DeclaringType))

            {

                return msg.Invoke(this.ElementList, args);

            }



            return msg.Invoke(elements, args);

        }

    }

}

