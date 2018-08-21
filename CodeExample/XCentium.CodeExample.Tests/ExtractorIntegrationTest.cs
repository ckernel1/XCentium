using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    /// <summary>
    /// Integration test for correctness. Ideally I would write a whole suite of automated test cases with static files, 
    /// but due to time constraints I have only included 3 static.
    /// </summary>
    public class ExtractorIntegrationTest
    {
        private string workingDirectory;
        private readonly List<string> searchTags = new List<string>() { "body", "meta", "title" };
        private readonly string excludeSymbolsRegEx = "[&,.?!:;#\"\r\n_\\\\]";
        public ExtractorIntegrationTest()
        {
            workingDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
        }
        [Fact]
        public void GoogleStaticTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
                                {
                                    URI = new Uri($"file://{workingDirectory}//StaticPages/google.html"),
                                    ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                                    SearchTags = searchTags} )
            {

                Assert.Equal(3, x.GetImages().Count());
                Assert.Equal(40, x.GetWords().Count());
                
            }
        }

        [Fact]
        public void CustomStaticNoImageTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"file://{workingDirectory}//StaticPages/test1.html"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.Empty( x.GetImages());
                Assert.Equal(17, x.GetWords().Count());

            }
        }


        [Fact]
        public void CustomStaticImageTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"file://{workingDirectory}//StaticPages/test2.html"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.Equal(2,x.GetImages().Count());
                Assert.Equal(17, x.GetWords().Count());

            }
        }

        [Fact]
        public void CustomStaticImageTitleTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"file://{workingDirectory}//StaticPages/test3.html"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.Equal(2, x.GetImages().Count());
                Assert.Equal(22, x.GetWords().Count());

            }
        }

    }
}
