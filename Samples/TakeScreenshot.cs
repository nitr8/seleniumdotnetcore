using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST.Selenium.Test;
using System.Threading.Tasks;

namespace ST.Test.Samples
{
    [TestClass]
    public class TakeScreenshot : SeleniumBase
    {
        [TestMethod]
        public void TimeDate()
        {
            Driver.Navigate().GoToUrl("https://www.timeanddate.com/");
            Driver.FindElementById("privacyframe_q2").Click();
            Helper.TakeScreenshot(Driver);
        }
    }
}
