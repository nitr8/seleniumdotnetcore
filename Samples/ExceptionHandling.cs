using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ST.Selenium.Test;

namespace ST.Test.Samples
{
    [TestClass]
    public class ExceptionHandling : SeleniumBase
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TryCatch()
        {
            Console.WriteLine($"{TestContext.TestName}|Start");
            try
            {
                Driver.Navigate().GoToUrl("http://google.com");
                Helper.TakeScreenshot(Driver);
                Console.WriteLine($"{TestContext.TestName}|WorkFlow \r\n Step dragged to canvas");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"{TestContext.TestName}|Failed");
                Assert.Fail($"\r\nTest: {TestContext.TestName}. \r\n{ex}");
            }
            Console.WriteLine($"{TestContext.TestName}|End");
        }

    }
}
