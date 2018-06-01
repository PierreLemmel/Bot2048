using OpenQA.Selenium;

namespace Bot2048.Automating
{
    internal interface IWebDriverFactory
    {
        IWebDriver BuildDriver();
    }
}
