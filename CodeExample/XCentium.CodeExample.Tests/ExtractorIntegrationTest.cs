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
    /// but due to time constraints I have only included one static and the others are pulled from the live sites which
    /// means they could change and cause the test to fail. 
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
        public void GoogleTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"http://google.com"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.Equal(2, x.GetImages().Count());
                Assert.Equal(39, x.GetWords().Count());

            }
        }

        [Fact]
        public void FacebookTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"http://facebook.com"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.Equal(6, x.GetImages().Count());
                Assert.Equal(333, x.GetWords().Count());

            }
        }

        [Fact]
        public void TwitterTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"http://twitter.com"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.Empty( x.GetImages());
                Assert.Equal(86, x.GetWords().Count());

            }
        }

    }
}
