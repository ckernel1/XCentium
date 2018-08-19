using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace XCentium.CodeExample.Libraries.WordCollector
{
    public class PassiveWebDriver<T> : IPassiveWebDriver<T> where T:class,IWebDriver
    {
        string _driverLocation = @".\Drivers";
        public PassiveWebDriver(string driverLocation = null) => _driverLocation = string.IsNullOrWhiteSpace(driverLocation) ? _driverLocation : driverLocation;
        public T GetWebDriver()
        {
            return Activator.CreateInstance(typeof(T), _driverLocation) as T;
            
        }

        
    }
}
