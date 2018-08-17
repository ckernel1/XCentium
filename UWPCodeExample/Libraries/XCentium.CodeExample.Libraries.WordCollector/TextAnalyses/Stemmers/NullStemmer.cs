using System.Globalization;
using XCentium.CodeExample.Libraries.WordCollector.Stemmers;

namespace XCentium.CodeExample.Libraries.WordCollector
{
    public class NullStemmer : IWordStemmer
    {
        public string GetStem(string word)
        {
            return word.ToLower(CultureInfo.InvariantCulture);
        }
    }
}
