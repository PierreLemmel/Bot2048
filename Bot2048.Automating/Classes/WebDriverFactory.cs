using System;
using System.Collections.Generic;
using Bot2048.Core;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace Bot2048.Automating
{
    internal class WebDriverFactory : IWebDriverFactory
    {
        private static class Browsers
        {
            public static readonly string Chrome = "Chrome";
            public static readonly string Opera = "Opera";
            public static readonly string Firefox = "Firefox";
            public static readonly string Edge = "Edge";
            public static readonly string InternetExplorer = "InternetExplorer";
        }

        private readonly IConfiguration configuration;

        private IReadOnlyDictionary<string, Func<IWebDriver>> driverFactoriesMap =
            new Dictionary<string, Func<IWebDriver>>(StringComparer.InvariantCultureIgnoreCase)
        {

        };

        public WebDriverFactory(IConfiguration config)
        {
            if (config is null) throw new ArgumentNullException(nameof(config));
        }

        public IWebDriver BuildDriver()
        {
            string browser = configuration["browser"];

            Func<IWebDriver> factoryMethod = driverFactoriesMap.GetValueOrDefault(browser, BuildChromeDriver);
            IWebDriver driver = factoryMethod.Invoke();

            return driver;
        }

        private IWebDriver BuildOperaDriver()
        {
            return new OperaDriver();
        }

        private IWebDriver BuildChromeDriver()
        {
            return new ChromeDriver();
        }

        private IWebDriver BuildFirefoxDriver()
        {
            return new FirefoxDriver();
        }
    }
}
