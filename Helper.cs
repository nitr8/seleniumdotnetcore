using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ST.Selenium.Test
{
    static class Helper
    {

        // https://stackoverflow.com/questions/3422262/take-a-screenshot-with-selenium-webdriver
        // IF scTimeStamp=0 disable appending "date/time" to filename else append 
        // IF user passes custom name from test method use that else if not used use Screenshot.png
        // IF scTimeStamp=0 & cName=Test = test.png
        // IF scTimeStamp=2 & cName=Test = test-15-1-2019_12-46.png
        // IF scTimeStamp=0 & cName=NULL = Screenshot.png
        // IF scTimeStamp=666 & cName=NULL = Screenshot-15-1-2019_12-46.png

        public static void TakeScreenshot(this IWebDriver driver, string path = Variables.scPath)
        {
            var cantakescreenshot = (driver as ITakesScreenshot) != null;
            if (!cantakescreenshot)
                return;
            var filename = string.Empty + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute;
            filename = path + @"\" + filename + ".png";
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            var screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            ss.SaveAsFile(filename, ScreenshotImageFormat.Png);
        }

        public static void Wait(int delay)
        {
            Task.Delay(delay).Wait();
        }

    }
}