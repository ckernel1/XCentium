using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist.En;
using XCentium.CodeExample.Libraries.WordCollector.Extractors;
using XCentium.CodeExample.Libraries.WordCollector.Stemmers;
using XCentium.CodeExample.Libraries.WordCollector.Stemmers.En;
using XCentium.CodeExample.Libraries.WordCollector.TextAnalyses;

namespace XCentium.CodeExample.Libraries.WordCollector
{
    public enum InputType { File,Uri}
    public static class Factory
    {
        public static IWordStemmer CreateWordStemmer(bool groupSameStemWords)
        {
            return groupSameStemWords
                       ? (IWordStemmer)new PorterStemmer()
                       : new NullStemmer();
        }

        public static IBlacklist CreateBlacklist(bool excludeEnglishCommonWords)
        {
            return excludeEnglishCommonWords
                       ? (IBlacklist)new CommonWords()
                       : new NullBlacklist();
        }

        public static IEnumerable<string> CreateExtractor(InputType inputType, IWebDriver webDriver, string input=null)
        {
            var progressCallback = new ProgressBarStatus();
            switch (inputType)
            {
                case InputType.File:
                    FileInfo fileInfo = new FileInfo(input);
                    return new FileExtractor(fileInfo, progressCallback);

                case InputType.Uri:
                    Uri uri = new Uri(input);
                    return new UriExtractor(progressCallback, webDriver);

                default:
                    return new StringExtractor(input, progressCallback);
            }
        }

       
    }
}
