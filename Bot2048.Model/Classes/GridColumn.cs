using System.Collections;
using System.Collections.Generic;

namespace Bot2048.Model
{
    public class GridColumn : IEnumerable<CellValue>
    {
        private readonly Grid grid;
        private readonly int col;

        internal GridColumn(Grid grid, int index)
        {
            this.grid = grid;
            col = index;
        }

        public CellValue this[int row]
        {
            get { return grid[col, row]; }
        }

        public IEnumerator<CellValue> GetEnumerator()
        {
            for(int row = 0; row <= 3; row++)
            {
                yield return this[row];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}