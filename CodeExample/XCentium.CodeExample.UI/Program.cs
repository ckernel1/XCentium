using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCentium.CodeExample.Libraries.WordCollector;
using XCentium.CodeExample.Libraries.WordCollector.Blacklist;
using XCentium.CodeExample.Libraries.WordCollector.Extractors;
using XCentium.CodeExample.Libraries.WordCollector.TextAnalyses;

namespace XCentium.CodeExample.UI
{
    static class Program
    {
        private static IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadIOCModule();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<WebAnalyzerForm>());
            
        }

        private static void LoadIOCModule()
        {
            // Create your builder.
            var builder = new ContainerBuilder();


            // Allows us to change the browser driver out easily.
            builder.RegisterType<PassiveWebDriver<FirefoxDriver>>().As<IPassiveWebDriver>();
            builder.RegisterType<ProgressBarStatus>().As<IProgressIndicator>();
            builder.RegisterInstance(CommonBlacklist.CreateFromTextFile(Properties.Resources.IgnoreList)).As<IBlacklist>();
            builder.RegisterType<WebAnalyzerForm>();
                        

            Container = builder.Build();
        }
    }
}
