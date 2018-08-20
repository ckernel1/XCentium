using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace XCentium.CodeExample.Libraries.WordCollector
{
    public interface IPassiveWebDriver
    {
        IWebDriver GetWebDriver();
    }
}
