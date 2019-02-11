using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using ST.Selenium.Test;
using System;

namespace ST.Test.Samples
{
    [TestClass]
    public class WebDrivers
    {
        string url = Variables.googleURL;
        string log = Variables.ieLog;

        [TestCategory("WebDrivers")]
        [Priority(1)]
        [TestMethod]
        public void Chrome()
        {
            var Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

        [TestCategory("WebDrivers")]
        [Priority(2)]
        [TestMethod]
        public void Chrome_Service()
        {
            var chromeService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var chromeOptions = new ChromeOptions();
            var Driver = new ChromeDriver(chromeService, chromeOptions);
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

        //[TestMethod]
        public void Chrome_Headless()
        {
            string driverPath = "/opt/selenium/";
            string driverExecutable = "chromedriver";

            var chromeService = ChromeDriverService.CreateDefaultService(driverPath, driverExecutable);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("no-sandbox");
            chromeOptions.BinaryLocation = "/opt/google/chrome/chrome";
            var Driver = new ChromeDriver(chromeService, chromeOptions, TimeSpan.FromSeconds(30));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Driver.Manage().Window.Maximize(); 
            Driver.Dispose();
        }

        [TestCategory("WebDrivers")]
        [TestMethod]
        public void Firefox()
        {
            var Driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

        [TestCategory("WebDrivers")]
        [TestMethod]
        public void InternetExplorer()
        {
            var Driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

        //[TestMethod]
        public void Edge()
        {
            var Driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

        [TestCategory("WebDrivers")]
        [TestMethod]
        public void InternetExplorer_Options()
        {
            var ieOptions = new InternetExplorerOptions
            {
                EnsureCleanSession = true
            };
            var Driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ieOptions);
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

        [TestCategory("WebDrivers")]
        [TestMethod]
        public void InternetExplorer_Service()
        {
            var ieDriverService = InternetExplorerDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var ieOptions = new InternetExplorerOptions();
            ieDriverService.LoggingLevel = InternetExplorerDriverLogLevel.Trace;
            ieDriverService.LogFile = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}"+log;
            var Driver = new InternetExplorerDriver(ieDriverService, ieOptions);
            Driver.Navigate().GoToUrl(url);
            Driver.Dispose();
        }

    }
}
