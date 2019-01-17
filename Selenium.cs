using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace ST.Selenium.Test
{
    public class SeleniumBase
    {
        public static RemoteWebDriver Driver { get; set; }

        public static WebDriverWait Wait { get; set; }

        [TestInitialize()]
        public void SetupTest()
        {
            // Setup webdriver
            switch (Variables.useBrowser)
            {
                case "Chrome":
                    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "ChromeOptions":
                String driverPath = "/opt/selenium/";
                String driverExecutableFileName = "chromedriver";
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("headless");
                options.AddArguments("no-sandbox");
                options.BinaryLocation = "/opt/google/chrome/chrome";
                ChromeDriverService service = ChromeDriverService.CreateDefaultService(driverPath,driverExecutableFileName);
                Driver = new ChromeDriver(service,options,TimeSpan.FromSeconds(30));
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                Driver.Manage().Window.Maximize();
                    //Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "InternetExplorer":
                    Driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "InternetExplorerOptions":
                    var ieDriverOptions = new InternetExplorerOptions
                    {
                        EnsureCleanSession = true,
                        //ForceCreateProcessApi = true,
                        //BrowserCommandLineArguments = "-private",
                        //IntroduceInstabilityByIgnoringProtectedModeSettings = true
                    };
                    Driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ieDriverOptions);
                    break;
                case "InternetExplorerService":
                    string log = Variables.ieLog;
                    var ieDriverService = InternetExplorerDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    var ieServiceOptions = new InternetExplorerOptions();
                    ieDriverService.LoggingLevel = InternetExplorerDriverLogLevel.Trace;
                    ieDriverService.LogFile = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}" + log;
                    ieServiceOptions.EnsureCleanSession = true;
                    Driver = new InternetExplorerDriver(ieDriverService, ieServiceOptions);
                    break;
                case "Edge":
                    Driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                default:
                    Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }
            //Driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            Wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(1000));

            Console.WriteLine($"Using {Driver}");
        }

        [TestCleanup()]
        public void CleanUp()
        {
            Console.WriteLine("CleanUp");
            Driver.Dispose();
        }
    }

}
