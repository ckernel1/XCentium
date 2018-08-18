using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPCodeExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn_Go_Click(object sender, RoutedEventArgs e)
        {
            IBlacklist blacklist = ComponentFactory.CreateBlacklist(true);
            //IBlacklist customBlacklist = CommonBlacklist.CreateFromTextFile(s_BlacklistTxtFileName);

            //InputType inputType = ComponentFactory.DetectInputType(textBox.Text);
            //IProgressIndicator progress = ComponentFactory.CreateProgressBar(inputType, progressBar);
            using (var document = new UriExtractor(new ProgressBar(), new FirefoxDriver(@"C:\Users\russell.lambright\Desktop")) { URI = new Uri("http://cnn.com") })
            {
                IWordStemmer stemmer = ComponentFactory.CreateWordStemmer(false);

                var words = document//.AsParallel()
                    .Filter(blacklist)
                    //.Filter(customBlacklist)
                    .CountOccurences()
                    .GroupByStem(stemmer)
                    .SortByOccurences();



                var topWords = words.Take(10).ToList();
                var sum = words.Sum(w => w.Occurrences);




                var images = document.GetImages();

            }
        }
    }
}
