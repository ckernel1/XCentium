using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCentium.CodeExample.UI
{
    public static class CustomSettings
    {
        public static int TopNumberOfWords => int.Parse(ConfigurationManager.AppSettings["TopNumberOfWords"]);
        public static string RegExExcludeSymbols => ConfigurationManager.AppSettings["RegExExcludeSymbols"];
        public static List<string> SearchTagNames => new List<string>(ConfigurationManager.AppSettings["SearchTagNames"].Split(','));
    }
}
