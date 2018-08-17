using HtmlAgilityPack;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace XCentium.CodeExample.Libraries.WordCollector.Extractors
{
    public class UriExtractor : FileExtractor
    {
        private readonly Uri m_Uri;
        
        private string _driverLocation = @".\Drivers";
        public UriExtractor(Uri uri, IProgressIndicator progressIndicator, string driverLocation=null)
            : base(null, progressIndicator)
        {
            _driverLocation = string.IsNullOrWhiteSpace(driverLocation) ? _driverLocation : driverLocation;
            m_Uri = uri;
        }

        public override IEnumerable<string> GetWords()
        {
            using (var webDriver = new FirefoxDriver(_driverLocation))
            {
                webDriver.Url = m_Uri.ToString();
                var body = webDriver.FindElementByTagName("body");

                var words = body.Text.Split(new string[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                ProgressIndicator.Reset();
                ProgressIndicator.Maximum = words.Count();
                foreach (string word in words)
                {
                    ProgressIndicator.Increment(1);
                    yield return word;
                }
            }

        }

        public IEnumerable<Tuple<string, string>> GetImages()
        {
            using (var webDriver = new FirefoxDriver(_driverLocation))
            {
                webDriver.Url = m_Uri.ToString();
                var images = webDriver.FindElementsByTagName("img");
                List<Tuple<string, string>> results = new List<Tuple<string, string>>();

                ProgressIndicator.Reset();
                ProgressIndicator.Maximum = images.Count;
                images.ToList().ForEach(i =>
                {
                    ProgressIndicator.Increment(1);
                    results.Add(Tuple.Create(i.GetAttribute("src"), i.GetAttribute("alt") ?? string.Empty));
                });
                return results;
            }
            
        }
    }
}
