using System;
using System.Collections;
using System.Collections.Generic;

namespace Bot2048.Model
{
    public class GridRow : IEnumerable<CellValue>
    {
        private readonly Grid grid;
        private readonly int row;

        internal GridRow(Grid grid, int index)
        {
            this.grid = grid;
            row = index;
        }

        public CellValue this[int col]
        {
            get { return grid[col, row]; }
        }

        public IEnumerator<CellValue> GetEnumerator()
        {
            for (int col = 0; col <= 3; col++)
            {
                yield return this[col];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}