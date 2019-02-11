using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST.Selenium.Test;

namespace ST.Test.Samples
{
    [TestClass]
    public class ElementHandling : SeleniumBase
    {
        [TestMethod]
        public void FindElement()
        {
            Driver.Navigate().GoToUrl(@"https://automatetheplanet.com/multiple-files-page-objects-item-templates/");
            //var link = Driver.FindElement(By.PartialLinkText("TFS Test API"));
            //var jsToBeExecuted = $"window.scroll(0, {link.Location.Y});";
            //((IJavaScriptExecutor)Driver).ExecuteScript(jsToBeExecuted);
            //var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            //var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("TFS Test API")));
            //clickableElement.Click();
        }

    }
}
