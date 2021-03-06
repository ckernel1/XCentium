﻿using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCentium.CodeExample.Libraries.WordCollector;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist;
using XCentium.CodeExample.Libraries.WordCollector.Extractors;
using XCentium.CodeExample.Libraries.WordCollector.Stemmers;
using XCentium.CodeExample.Libraries.WordCollector.Processing;
using XCentium.CodeExample.Libraries.WordCollector.TextAnalyses;
using System.Threading;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace XCentium.CodeExample.UI
{

    public partial class WebAnalyzerForm : Form
    {

        private BindingSource topWordsBindingSource = new BindingSource();

        IBlacklist customIgnorelist;

        IPassiveWebDriver webDriver = new PassiveWebDriver<FirefoxDriver>();
        IProgressIndicator progressIndicator;// = new ProgressBarStatus();
        delegate object ThreadedAPICall();
        delegate void LocalizedUIOperation();
        List<WordGroup> _lastGroupOfWords;
        public WebAnalyzerForm(IPassiveWebDriver webDriver, IProgressIndicator progressIndicator, IBlacklist customIgnorelist)
        {
            this.webDriver = webDriver;
            this.progressIndicator = progressIndicator;
            this.customIgnorelist = customIgnorelist;

            InitializeComponent();

        }
        

        private void btn_Go_Click(object sender, EventArgs e)
        {
            // Used factory pattern here instead of DI because the user can change these at will during runtime. 
            IWordStemmer stemmer = Factory.CreateWordStemmer(cb_grouping.Checked); 
            IBlacklist blacklist = Factory.CreateBlacklist(cb_ignoreCommonwords.Checked);

            // Perform in another thread to keep the UI active and display animation to the user. 
            DoWait(() =>
            {
                var task = Task.Run(() =>
                {
                    using (var document = new UriExtractor(progressIndicator, webDriver.GetWebDriver()) { URI = new Uri(Normalize(txt_URL.Text)) })
                    {
                        document.SearchTags.Clear();
                        document.SearchTags.AddRange(CustomSettings.SearchTagNames);
                        document.ExcludeSymbolsRegEx = CustomSettings.RegExExcludeSymbols;

                        _lastGroupOfWords = document
                            .Filter(blacklist)
                            .Filter(customIgnorelist)
                            .OrderBy(w => w) // Sort alpabetically
                            .CountOccurences()
                            .GroupByStem(stemmer)
                            .SortByOccurences()// Sort by occurences
                            .ToList(); // Remove deffered execution as Extractor will be disposed after this method ends.


                        // Compute top n words.
                        var topWords = _lastGroupOfWords.Take(CustomSettings.TopNumberOfWords);
                        
                        SetWordList(topWords);
                        DoLocal(() => ClearImageList());
                        var images = document.GetImages();
                        foreach (var image in images)
                        {
                            var imageObj = GetImage(image.Item1);
                            if (imageObj == null)
                                continue;
                            DoLocal(() => imagesFromCurrentSite.Images.Add(image.Item1, imageObj));
                            DoLocal(() => lv_images.Items.Add(new ListViewItem(image.Item2, image.Item1) {ToolTipText="Click the image to display full size." }));
                        }
                    }
                });

                // Set callback to check for any errors during execution
                task.GetAwaiter().OnCompleted(() =>
                {
                    if (task.Exception != null)
                    {
                        DoLocal(() => MessageBox.Show(this, $"Sorry the following error occured while trying to execute your last request:\r\n {GetErrorMessage(task.Exception)}"), true);
                        DoLocal(() => txt_URL.BackColor = Color.Red);
                    }else
                    {
                        DoLocal(() => txt_URL.BackColor = Color.Green);
                    }
                });

                // Wait until the task is done so the progress bar doesn't go away. 
                task.Wait();
            });
            
        }

        private void SetWordList(IEnumerable<WordGroup> words)
        {


            DoLocal(() =>
                    {
                        // Clear previous list
                        topWordsBindingSource.Clear();
                        if (words == null)
                            return;
                        foreach (var word in words)
                            topWordsBindingSource.Add(word);

                        // Bind new words
                        dgv_TopWords.DataSource = topWordsBindingSource;

                        // Set Total Word count
                        ll_wordCount.Text = $"{_lastGroupOfWords.Sum(w => w.Occurrences)} words";

                    });
        }

        /// <summary>
        /// Recursive method to get the root cause of an exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private string GetErrorMessage(Exception exception)
        {
            if (exception.InnerException == null)
                return exception.Message;
           return GetErrorMessage(exception.InnerException);
        }

       
        /// <summary>
        /// This removes images and disposes of them since we are done with them
        /// </summary>
        /// <param name="images"></param>
        private void ClearImageList()
        {
            foreach (Image image in imagesFromCurrentSite.Images)
                image.Dispose();
            imagesFromCurrentSite.Images.Clear();
            lv_images.Clear();
        }

        /// <summary>
        /// Quick method to ensure the user did not leave off the http or https
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string Normalize(string text)
        {
            if(!Regex.IsMatch(text, "^(http:|https:|HTTP:|HTTPS:|Http:|Https:|FILE:|File:|file:).*"))
                return $"http://{text}";
            return text;
        }

        /// <summary>
        /// Gets the image from the source url and places it in memory
        /// </summary>
        /// <param name="webPath"></param>
        /// <returns></returns>
        private Image GetImage(string webPath)
        {
            if (string.IsNullOrWhiteSpace(webPath))
                return null;

            using (var wc = new WebClient())
            {
               
                {

                    MemoryStream imgStream = null;
                    // This could be refactored to find the media type first then find the proper way to convert it to a bitmap.
                    try
                    {
                        imgStream = new MemoryStream(wc.DownloadData(webPath));
                        if (imgStream.Length <= 1)
                            return Image.FromFile(@".\invalidImageFormat.png"); // invalid image
                        // Regular images will pass through here.
                        return Image.FromStream(imgStream);
                    }
                    catch
                    {
                        
                        try
                        {   // Reset stream and try again as a vector image. 
                            imgStream.Position = 0;
                            // Vector images will pass through here. 
                            var doc = Svg.SvgDocument.Open<Svg.SvgDocument>(imgStream);
                            return doc.Draw();
                        }
                        catch
                        {
                            // If all else fails show invalid format image.

                            return Image.FromFile(@".\invalidImageFormat.png");
                        }

                    }
                    
                }
            }
        }
        private void lv_images_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in (sender as ListView).SelectedItems)
            {
                new ViewerForm() {CurrentImage=GetImage(item.ImageKey),Title=item.Text }.Show(this);
            }
            // Unselect indecies
            (sender as ListView).SelectedIndices.Clear();
        }
        /// <summary>
        /// Handles tasks that need to be executed on the main thread.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        private object DoLocal(Func<object> func)
        {

            return Invoke(new ThreadedAPICall(func));

        }
        /// <summary>
        /// Handles tasks that need to be executed on the main thread.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        private object DoLocal(Action func,bool startFromSeperateThread=false)
        {

            return startFromSeperateThread?Task.Run(()=>Invoke(func)): Invoke(func);

        }
        /// <summary>
        /// Method I created that allows you to run code in another thread and show a wait dialog to the user so they know something is happening. 
        /// </summary>
        /// <param name="func"></param>
        private void DoWait(Action func) 
        {
            var wait = new WaitForm();
            func.BeginInvoke(new AsyncCallback(AysncAPICallEnded), wait);
            wait.ShowDialog(this);
        }
        /// <summary>
        /// Used to terminate the wait form.
        /// </summary>
        /// <param name="result"></param>
        void AysncAPICallEnded(IAsyncResult result)
        {
            
            if (result.IsCompleted)
                Invoke(new LocalizedUIOperation((result.AsyncState as WaitForm).Close));
        }

        private void ll_wordCount_Click(object sender, EventArgs e)
        {
            // Toggle between full word list and top n word list.
            SetWordList(dgv_TopWords.Rows.Count < _lastGroupOfWords?.Count?_lastGroupOfWords:_lastGroupOfWords?.Take(CustomSettings.TopNumberOfWords));
        }
    }
}
