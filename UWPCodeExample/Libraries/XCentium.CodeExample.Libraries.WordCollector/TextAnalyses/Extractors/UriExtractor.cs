
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace XCentium.CodeExample.Libraries.WordCollector.Extractors
{
    public class UriExtractor : FileExtractor,IDisposable
    {
        
        private IWebDriver _webDriver;
        public UriExtractor( IProgressIndicator progressIndicator, IWebDriver webDriver, string driverLocation=null)
            : base(null, progressIndicator)
        {
            
            _webDriver = webDriver;
        }

        public Uri URI { get; set; }
        public override IEnumerable<string> GetWords()
        {
           
                _webDriver.Url = URI.ToString();
                var body = _webDriver.FindElement(By.TagName("body"));

                var words = body.Text.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                ProgressIndicator.Reset();
                ProgressIndicator.Maximum = words.Count();
                foreach (string word in words)
                {
                    ProgressIndicator.Increment(1);
                    yield return word;
                }
            

        }

        public IEnumerable<Tuple<string, string>> GetImages()
        {
            
               _webDriver.Url = URI.ToString();
                var images = _webDriver.FindElements(By.TagName("img"));
                List<Tuple<string, string>> results = new List<Tuple<string, string>>();

                ProgressIndicator.Reset();
                ProgressIndicator.Maximum = images.Count;
                foreach(var image in images)
                {
                    ProgressIndicator.Increment(1);
                    results.Add(Tuple.Create(image.GetAttribute("src"), image.GetAttribute("alt") ?? string.Empty));
                };
                return results;
            
            
        }

        public void Dispose()
        {
            _webDriver?.Dispose();
        }
    }
}
