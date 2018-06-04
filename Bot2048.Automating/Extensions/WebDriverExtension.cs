using Bot2048.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot2048.Automating
{
    internal static class WebDriverExtension
    {
        public static async Task AwaitDocumentReady(this IWebDriver webDriver)
        {
            Check.NotNull(webDriver, nameof(webDriver));

            while (webDriver.IsDocumentReady())
                await Task.Delay(100);
        }

        public static bool IsDocumentReady(this IWebDriver webDriver)
        {
            Check.NotNull(webDriver, nameof(webDriver));

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)webDriver;
            object scriptResult = jsExecutor.ExecuteScript("return document.readyState");
            bool documentReady = scriptResult.Equals("complete");

            return documentReady;
        }

        public static bool HasElement(this IWebDriver webDriver, By by)
        {
            Check.NotNull(webDriver, nameof(webDriver));

            IEnumerable<IWebElement> elts = webDriver.FindElements(by);
            return elts.Any();
        }
    }
}