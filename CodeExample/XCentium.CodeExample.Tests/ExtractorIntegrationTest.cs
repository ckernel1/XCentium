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
    /// means they could change and cause the test to fail. For that reason I used inrange to give some degree of flexibility. 
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

                Assert.InRange( x.GetImages().Count(),1,4);
                Assert.InRange( x.GetWords().Count(),37,42);

            }
        }

        [Fact]
        public void StateFarmTest()
        {
            using (var x = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(workingDirectory))
            {
                URI = new Uri($"http://statefarm.com"),
                ExcludeSymbolsRegEx = excludeSymbolsRegEx,
                SearchTags = searchTags
            })
            {

                Assert.InRange(x.GetImages().Count(),10,18 );
                Assert.InRange( x.GetWords().Count(),1010,1030);

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
                Assert.InRange( x.GetWords().Count(),82,90);

            }
        }

    }
}
