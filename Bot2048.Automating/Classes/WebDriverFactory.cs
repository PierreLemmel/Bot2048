﻿using System;
using System.Collections.Generic;
using Bot2048.Core;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
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

        private IReadOnlyDictionary<string, Func<IWebDriver>> driverFactoriesMap;

        public WebDriverFactory(IConfiguration config)
        {
            Check.NotNull(config, nameof(config));

            driverFactoriesMap = new Dictionary<string, Func<IWebDriver>>(StringComparer.InvariantCultureIgnoreCase)
            {
                { Browsers.Chrome, BuildChromeDriver },
                { Browsers.Opera, BuildOperaDriver },
                { Browsers.Firefox, BuildFirefoxDriver },
                { Browsers.Edge, BuildEdgeDriver },
                { Browsers.InternetExplorer, BuildIEDriver },
            };

            configuration = config;
        }
        
        public IWebDriver BuildDriver()
        {
            string browser = configuration["browser"];

            Func<IWebDriver> factoryMethod = driverFactoriesMap.GetValueOrDefault(browser, BuildChromeDriver);
            IWebDriver driver = factoryMethod.Invoke();

            return driver;
        }

        private IWebDriver BuildOperaDriver() => new OperaDriver();
        private IWebDriver BuildChromeDriver() => new ChromeDriver();
        private IWebDriver BuildFirefoxDriver() => new FirefoxDriver();
        private IWebDriver BuildEdgeDriver() => new EdgeDriver();
        private IWebDriver BuildIEDriver() => new InternetExplorerDriver();
    }
}