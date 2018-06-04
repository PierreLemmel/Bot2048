using Bot2048.Model;
using System.Collections.Generic;

namespace Bot2048.Logic
{
    public interface IGridUpdater
    {
        void UpdateGrid(Grid grid, IEnumerable<GridUpdateInput> inputs);
    }
}