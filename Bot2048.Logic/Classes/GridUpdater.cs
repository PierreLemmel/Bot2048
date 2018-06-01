using System.Collections.Generic;
using Bot2048.Model;

namespace Bot2048.Logic
{
    internal class GridUpdater : IGridUpdater
    {
        public void UpdateGrid(Grid grid, IEnumerable<GridUpdateInput> inputs)
        {
            grid.Clear();

            foreach(GridUpdateInput input in inputs)
            {
                grid[input.Column, input.Row] = input.Value;
            }
        }
    }
}
