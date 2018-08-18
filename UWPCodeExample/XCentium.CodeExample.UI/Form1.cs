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

namespace XCentium.CodeExample.UI
{

    public partial class Form1 : Form
    {
        private BindingSource topWordsBingingSource = new BindingSource();


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            IBlacklist blacklist = Factory.CreateBlacklist(true);
            IBlacklist customIgnorelist = CommonBlacklist.CreateFromTextFile(Properties.Resources.IgnoreList);


            using (var document = new UriExtractor(new ProgressBarStatus(), new FirefoxDriver(@".\Drivers")) { URI = new Uri(Normalize(txt_URL.Text)) })
            {
                IWordStemmer stemmer = Factory.CreateWordStemmer(false);

                var words = document
                    .Filter(blacklist)
                    .Filter(customIgnorelist)
                    .CountOccurences()
                    .GroupByStem(stemmer)
                    .SortByOccurences();



                var topWords = words.Take(10).ToList();
                var sum = words.Sum(w => w.Occurrences);


                var images = document.GetImages();
                topWordsBingingSource.Clear();
                topWords.ForEach(w => topWordsBingingSource.Add(w));
                dgv_TopWords.DataSource = topWordsBingingSource;

                ClearImageList();
                foreach (var image in images)
                {


                    imagesFromCurrentSite.Images.Add(image.Item1, GetImage(image.Item1));
                    lv_images.Items.Add(new ListViewItem(image.Item2, image.Item1));

                }


            }
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
        }
    }
}
