using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DOmainUI.Framework.PageObjectFactory
{
    public class WebElementProxy<T> : DispatchProxy, IWrapsElement

    {

        private IWebElement cachedElement;

        private Type classtoProxy;

        private IElementLocator locator;

        protected IEnumerable<By> bys;



        /// <summary>

        /// Gets the <see cref="IWebElement"/> wrapped by this object.

        /// </summary>

        public IWebElement WrappedElement

        {

            get { return this.Element; }

        }



        /// <summary>

        /// Gets the IWebElement object this proxy represents, returning a cached one if requested.

        /// </summary>

        private IWebElement Element

        {

            get

            {

                if (this.cachedElement == null)

                {

                    this.cachedElement = locator.LocateElement(bys);

                }



                return this.cachedElement;

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

            object proxy = Create<T, WebElementProxy<T>>();

            ((WebElementProxy<T>)proxy).SetParamateres(classToProxy, locator, bys);

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

            var elements = this.Element;

            if (typeof(IWrapsElement).IsAssignableFrom((msg.DeclaringType)))

            {

                return msg.ReturnParameter;

            }



            return msg.Invoke(elements, args);

        }

    }

}


