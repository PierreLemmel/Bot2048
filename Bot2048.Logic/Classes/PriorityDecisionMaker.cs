using System;
using Bot2048.Core;
using Bot2048.Model;

namespace Bot2048.Logic
{
    /// <summary>
    /// DecisionMaker based on the following priorities:
    /// - If Down is available, go down
    /// - Else, if Left is available, go Left
    /// - Else, if right is available, go Right
    /// - Else, go Up
    /// </summary>
    internal class PriorityDecisionMaker : IDecisionMaker
    {
        private readonly IGameAnalyzer gameAnalyzer;

        public PriorityDecisionMaker(IGameAnalyzer analyzer)
        {
            Check.NotNull(analyzer, nameof(analyzer));

            gameAnalyzer = analyzer;
        }

        public Direction ChoseDirection(Grid grid)
        {
            if (gameAnalyzer.CanMoveDown(grid))
                return Direction.Down;
            if (gameAnalyzer.CanMoveLeft(grid))
                return Direction.Left;
            if (gameAnalyzer.CanMoveRight(grid))
                return Direction.Right;
            else
                return Direction.Up;
        }
    }
}
