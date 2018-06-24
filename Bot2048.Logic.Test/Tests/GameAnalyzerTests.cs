using Bot2048.Model;
using NUnit.Framework;
using System;

using static Bot2048.Model.CellValue;

namespace Bot2048.Logic.Test
{
    [TestFixture(TestOf = typeof(GameAnalyzer))]
    public class GameAnalyzerTests
    {
        private GameAnalyzer gameAnalyzer;

        [OneTimeSetUp]
        public void TestSetup()
        {
            gameAnalyzer = new GameAnalyzer();
        }

        #region CanMoveLeft
        [Test]
        public void CanMoveLeft_WhenGridNull_Throw_ArgumentNullException()
        {
            Grid grid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bool result = gameAnalyzer.CanMoveLeft(grid);
            });
        }

        [Test]
        public void CanMoveLeft_WhenRowIsEmpty_Returns_False()
        {
            Grid grid = new Grid(new CellValue[4, 4]
            {
                { Empty, Empty, Empty, Empty },
                { Empty, Empty, Empty, Empty },
                { Empty, Empty, Empty, Empty },
                { Empty, Empty, Empty, Empty },
            });

            bool expected = false;
            bool actual = gameAnalyzer.CanMoveLeft(grid);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(GameAnalyzerTestSource), nameof(GameAnalyzerTestSource.TestCases_CanMoveLeft_WhenRowIsFilled_And_NoConsecutiveValues))]
        public void CanMoveLeft_WhenRowIsFilled_And_NoConsecutiveValues_Returns_False(Grid grid)
        {
            bool expected = false;
            bool actual = gameAnalyzer.CanMoveLeft(grid);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(GameAnalyzerTestSource), nameof(GameAnalyzerTestSource.TestCases_CanMoveLeft_WhenRowIsFilled_And_ConsecutiveValues))]
        public void CanMoveLeft_WhenRowIsFilled_And_ConsecutiveValues_Returns_True(Grid grid)
        {
            bool expected = true;
            bool actual = gameAnalyzer.CanMoveLeft(grid);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(GameAnalyzerTestSource), nameof(GameAnalyzerTestSource.TestCases_CanMoveLeft_WhenRowContainsOneEmptyCells_NotAtTheMostRight))]
        public void CanMoveLeft_WhenRowContainsOneEmptyCells_NotAtTheMostRight_Returns_True(Grid grid)
        {
            bool expected = true;
            bool actual = gameAnalyzer.CanMoveLeft(grid);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanMoveLeft_WhenRowContainsOneEmptyCells_AtTheMostRight_Returns_False()
        {
            Grid grid = new Grid(new CellValue[4, 4]
            {
                { Value2, Value4, Value8, Empty },
                { Empty , Empty , Empty , Empty },
                { Empty , Empty , Empty , Empty },
                { Empty , Empty , Empty , Empty },
            });

            bool expected = false;
            bool actual = gameAnalyzer.CanMoveLeft(grid);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(GameAnalyzerTestSource), nameof(GameAnalyzerTestSource.TestCases_CanMoveLeft_WhenRowContains2Or3EmptyCells))]
        public void CanMoveLeft_WhenRowContains2Or3EmptyCells_Returns_True(Grid grid)
        {
            bool expected = true;
            bool actual = gameAnalyzer.CanMoveLeft(grid);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        [Test]
        public void CanMoveRight_WhenGridNull_Throw_ArgumentNullException()
        {
            Grid grid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bool result = gameAnalyzer.CanMoveRight(grid);
            });
        }

        [Test]
        public void CanMoveDown_WhenGridNull_Throw_ArgumentNullException()
        {
            Grid grid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bool result = gameAnalyzer.CanMoveDown(grid);
            });
        }

        [Test]
        public void CanMoveUp_WhenGridNull_Throw_ArgumentNullException()
        {
            Grid grid = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bool result = gameAnalyzer.CanMoveUp(grid);
            });
        }
    }
}