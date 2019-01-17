using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST.Selenium.Test;

namespace ST.Test.Samples
{
    [TestClass]
    public class TakeScreenshot : SeleniumBase
    {
        [TestMethod]
        public void TestName2()
        {
            Driver.Navigate().GoToUrl("https://www.timeanddate.com/");
            Helper.TakeScreenshot(Driver);
        }
    }
}
