using OpenQA.Selenium.Firefox;
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

    public partial class Form1 : Form
    {
        private BindingSource topWordsBindingSource = new BindingSource();
        IBlacklist blacklist = Factory.CreateBlacklist(true);
        IBlacklist customIgnorelist = CommonBlacklist.CreateFromTextFile(Properties.Resources.IgnoreList);
        IWordStemmer stemmer = Factory.CreateWordStemmer(false);
        IPassiveWebDriver<FirefoxDriver> webDriver = new PassiveWebDriver<FirefoxDriver>();
        IProgressIndicator progressIndicator = new ProgressBarStatus();
        delegate object ThreadedAPICall();
        delegate void LocalizedUIOperation();
        public Form1() => InitializeComponent();
        

        private void btn_Go_Click(object sender, EventArgs e)
        {
            Task task;
            DoWait(() =>
            {
                task = Task.Run(() =>
                {
                    using (var document = new UriExtractor(progressIndicator, webDriver.GetWebDriver()) { URI = new Uri(Normalize(txt_URL.Text)) })
                    {
                        var words = document
                            .Filter(blacklist)
                            .Filter(customIgnorelist)
                            .CountOccurences()
                            .GroupByStem(stemmer)
                            .SortByOccurences();

                        // Compute top n words.
                        var topWords = words.Take(10).ToList();
                        var sum = words.Sum(w => w.Occurrences);

                        DoLocal(() =>
                        {
                            // Clear previous list
                            topWordsBindingSource.Clear();
                            topWords.ForEach(w => topWordsBindingSource.Add(w));

                            // Bind new words
                            dgv_TopWords.DataSource = topWordsBindingSource;
                            ClearImageList();
                        });



                        var images = document.GetImages();
                        foreach (var image in images)
                        {
                            DoLocal(() => imagesFromCurrentSite.Images.Add(image.Item1, GetImage(image.Item1)));
                            DoLocal(() => lv_images.Items.Add(new ListViewItem(image.Item2, image.Item1)));
                        }
                    }
                });
                task.GetAwaiter().OnCompleted(() =>
                {
                    if (task.Exception != null)
                        MessageBox.Show($"Sorry the following error occured while trying to execute your last request:\r\n {GetErrorMessage(task.Exception)}");
                });
                task.Wait();
            });
            

            // Set callback to check for any errors during execution
            
            
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
            if(!Regex.IsMatch(text, "^(http:|https:|HTTP:|HTTPS:|Http:|Https:).*"))
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
            using (var wc = new WebClient())
            {
                using (var imgStream = new MemoryStream(wc.DownloadData(webPath)))
                {
                    using (Bitmap bitmap = new Bitmap(imgStream))
                    {
                        return new Bitmap(bitmap);
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
        private object DoLocal(Action func)
        {

            return Invoke(func);

        }
        private void DoWait<T>(Func<T> func) where T : class
        {
            var wait = new WaitForm();
            func.BeginInvoke( new AsyncCallback(AysncAPICallEnded), wait);
            wait.ShowDialog(this);
        }
        private void DoWait(Action func) 
        {
            var wait = new WaitForm();
            func.BeginInvoke(new AsyncCallback(AysncAPICallEnded), wait);
            wait.ShowDialog(this);
        }
        void AysncAPICallEnded(IAsyncResult result)
        {
            
            if (result.IsCompleted)
                Invoke(new LocalizedUIOperation((result.AsyncState as WaitForm).Close));
        }

    }
}
