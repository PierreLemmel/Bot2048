using Bot2048.Core;
using Bot2048.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bot2048.Automating
{
    internal class AutomatingControler : IAutomatingControler
    {
        private readonly IWebDriver webDriver;
        private readonly IConfiguration configuration;

        private IWebElement tileContainer;

        private IReadOnlyDictionary<Direction, string> directionKeyMap = new Dictionary<Direction, string>()
        {
            { Direction.Left, Keys.ArrowLeft },
            { Direction.Right, Keys.ArrowRight },
            { Direction.Up, Keys.ArrowUp },
            { Direction.Down, Keys.ArrowDown }
        };

        public AutomatingControler(IWebDriverFactory driverFactory, IConfiguration config)
        {
            Check.NotNull(driverFactory, nameof(driverFactory));
            Check.NotNull(config, nameof(config));

            webDriver = driverFactory.BuildDriver();
            configuration = config;
        }

        public async Task OpenWebPage()
        {
            string url = configuration["mainPageUrl"];
            webDriver.Navigate().GoToUrl(url);

            await webDriver.AwaitDocumentReady();

            tileContainer = webDriver.FindElement(By.CssSelector("div.tile-container"));
        }

        public async Task NextStep(Direction direction)
        {
            IWebElement gridContainer = webDriver.FindElement(By.CssSelector("body"));

            string key = directionKeyMap.GetValueOrDefault(direction, "");

            gridContainer.SendKeys(key);

            await Task.Delay(200);
        }

        public async Task Replay()
        {
            IWebElement retryButton = webDriver.FindElement(By.CssSelector("a.retry-button"));
            retryButton.Click();

            await Task.Delay(500);
        }

        public bool DetectGameOver()
        {
            return webDriver.HasElement(By.CssSelector("div.game-over"));
        }

        public int ReadScore()
        {
            IWebElement scoreElement = webDriver.FindElement(By.CssSelector("div.score-container"));
            int score = int.Parse(scoreElement.Text);

            return score;
        }

        public IEnumerable<GridUpdateInput> ReadGridState()
        {
            IEnumerable<IWebElement> tiles = tileContainer.FindElements(By.CssSelector("div.tile"));

            ICollection<GridUpdateInput> inputs = new List<GridUpdateInput>();
            foreach(IWebElement tile in tiles)
            {
                string[] classes = tile.GetClasses();

                #region Parse value
                string valueClass = classes[1];
                string valueStr = valueClass.Split('-')[1];
                int valueInt = int.Parse(valueStr);
                CellValue value = (CellValue)valueInt;
                #endregion

                #region Parse row / column
                string positionClass = classes[2];
                string[] positionChunks = positionClass.Split('-');
                int col = int.Parse(positionChunks[2]) - 1;
                int row = 4 - int.Parse(positionChunks[3]);
                #endregion

                GridUpdateInput input = new GridUpdateInput()
                {
                    Row = row,
                    Column = col,
                    Value = value
                };

                inputs.Add(input);
            }

            return inputs;
        }
    }
}