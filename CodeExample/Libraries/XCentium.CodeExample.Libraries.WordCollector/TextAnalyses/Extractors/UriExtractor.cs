
using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace XCentium.CodeExample.Libraries.WordCollector.Extractors
{
    public class UriExtractor : FileExtractor,IDisposable
    {
        
        public List<string> SearchTags { get; set; }
        public string ExcludeSymbolsRegEx { get; set; } 
        private IWebDriver _webDriver;
        public UriExtractor( IProgressIndicator progressIndicator, IWebDriver webDriver, string driverLocation=null)
            : base(null, progressIndicator)
        {
            // Set Defaults
            SearchTags = new List<string>(new string[] {"body" });
            _webDriver = webDriver;
            ExcludeSymbolsRegEx = "[&,.?!:;#\"\r\n]";
        }

        public Uri URI { get; set; }
        public override IEnumerable<string> GetWords()
        {
            //_webDriver.Navigate().GoToUrl(URI.ToString());
            _webDriver.Url = URI.ToString();
            List<string> words = new List<string>();

            SearchTags.ForEach(t =>
            {
                var elements = _webDriver.FindElements(By.TagName(t));
                
                foreach (IWebElement element in elements)
                {
                    
                    // Going to look at content attributes, value attributes and inner text for words. 
                    var analyzeThis = string.Concat(element.GetAttribute("content")," " , element.GetAttribute("value")," " , element.Text);
                    AddWords(analyzeThis,words);
                }
                // Special case for title tag
                if (string.Equals("title", t, StringComparison.OrdinalIgnoreCase))
                    AddWords(_webDriver.Title,words);

            });
            
            ProgressIndicator.Reset();
            ProgressIndicator.Maximum = words.Count();
            foreach (string word in words)
            {
                ProgressIndicator.Increment(1);
                yield return word;
            }


        }

        private void AddWords(string words,List<string> wordList)
        {
            wordList.AddRange(Regex
                   .Replace(words, ExcludeSymbolsRegEx, " ")?
                   .ToLower()
                   .Split(new char[] { ' ' }, options: StringSplitOptions.RemoveEmptyEntries));
        }

        public IEnumerable<Tuple<string, string>> GetImages()
        {

            _webDriver.Url = URI.ToString();
            var images = _webDriver.FindElements(By.TagName("img"));
            List<Tuple<string, string>> results = new List<Tuple<string, string>>();

            ProgressIndicator.Reset();
            ProgressIndicator.Maximum = images.Count;
            foreach (var image in images)
            {
                ProgressIndicator.Increment(1);
                try
                {
                    results.Add(Tuple.Create(image.GetAttribute("src"), image.GetAttribute("alt") ?? string.Empty));
                }
                catch (StaleElementReferenceException) { Console.WriteLine($"An image was removed from the page or its url changed before it gould be loaded in the collection."); }// Skipping this exception as it referes to an element that is no longer present.
            }
            return results?.Where(i=>!string.IsNullOrWhiteSpace(i.Item1));


        }

        public void Dispose()
        {
            _webDriver?.Dispose();
        }
    }
}
