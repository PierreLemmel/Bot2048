using Bot2048.Core;
using OpenQA.Selenium;
using System;

namespace Bot2048.Automating
{
    internal static class WebElementExtension
    {
        public static string[] GetClasses(this IWebElement webElement)
        {
            Check.NotNull(webElement, nameof(webElement));

            string[] classes = webElement
                .GetAttribute("class")
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return classes;
        }
    }
}