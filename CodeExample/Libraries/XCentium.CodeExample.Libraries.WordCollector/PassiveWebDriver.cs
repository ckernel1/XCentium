using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace XCentium.CodeExample.Libraries.WordCollector
{
    public class PassiveWebDriver<T> : IPassiveWebDriver where T:class,IWebDriver
    {
        
        public IWebDriver GetWebDriver()
        {
            return Activator.CreateInstance(typeof(T)) as T;
            
        }

        
    }
}
