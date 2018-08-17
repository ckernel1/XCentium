using System;
using System.Collections.Generic;
using System.Linq;
using XCentium.CodeExample.Libraries.WordCollector;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist.En;
using XCentium.CodeExample.Libraries.WordCollector.Extractors;
using XCentium.CodeExample.Libraries.WordCollector.Processing;
using XCentium.CodeExample.Libraries.WordCollector.Stemmers;
using XCentium.CodeExample.Libraries.WordCollector.Stemmers.En;
using XCentium.CodeExample.Libraries.WordCollector.TextAnalyses;
using Xunit;

namespace XCentium.CodeExample.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            UriExtractor x = new UriExtractor(new Uri("http://google.com"),new ProgressBar(), @"C:\Users\russell.lambright\Desktop" );

            var test = x.GetImages();
            var test2 = x.GetWords();
        }
        [Fact]
        public void FullTest()
        {
            IBlacklist blacklist = ComponentFactory.CreateBlacklist(false);
            //IBlacklist customBlacklist = CommonBlacklist.CreateFromTextFile(s_BlacklistTxtFileName);

            //InputType inputType = ComponentFactory.DetectInputType(textBox.Text);
            //IProgressIndicator progress = ComponentFactory.CreateProgressBar(inputType, progressBar);
            IEnumerable<string> terms = new UriExtractor(new Uri("http://google.com"), new ProgressBar(), @"C:\Users\russell.lambright\Desktop");
            IWordStemmer stemmer = ComponentFactory.CreateWordStemmer(false);

            IEnumerable<IWord> words = terms
                .Filter(blacklist)
                //.Filter(customBlacklist)
                .CountOccurences().ToList();

            var end =
                words
                    .GroupByStem(stemmer)
                    .SortByOccurences()
                    .ToList();
                    //.Cast<IWord>();
        }

        internal static class ComponentFactory
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

            //public static IEnumerable<string> CreateExtractor(InputType inputType, string input, IProgressIndicator progress)
            //{
            //    switch (inputType)
            //    {
            //        case InputType.File:
            //            FileInfo fileInfo = new FileInfo(input);
            //            return new FileExtractor(fileInfo, progress);

            //        case InputType.Uri:
            //            Uri uri = new Uri(input);
            //            return new UriExtractor(uri, progress);

            //        default:
            //            return new StringExtractor(input, progress);
            //    }
            //}

            //public static IProgressIndicator CreateProgressBar(InputType inputType, ProgressBar progressBar)
            //{
            //    return
            //        inputType == InputType.String ?
            //                                        new ProgressBarWrapper(progressBar) :
            //                                                                                new InfiniteProgressBarWrapper(progressBar);
            //}

            //public static InputType DetectInputType(string input)
            //{
            //    if (input.Length < 0x200)
            //    {
            //        if (input.StartsWith("http", true, CultureInfo.InvariantCulture))
            //        {
            //            return InputType.Uri;
            //        }
            //        if (File.Exists(input))
            //        {
            //            return InputType.File;
            //        }
            //    }
            //    return InputType.String;
            //}
        }
    }
}
