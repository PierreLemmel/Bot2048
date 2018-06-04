using System;
using System.Collections;
using System.Collections.Generic;

namespace Bot2048.Model
{
    public class GridRowCollection : IEnumerable<GridRow>
    {
        private readonly Grid grid;

        internal GridRowCollection(Grid grid)
        {
            this.grid = grid;
        }

        public GridRow this[int row]
        {
            get { return new GridRow(grid, row); }
        }

        public IEnumerator<GridRow> GetEnumerator()
        {
            for (int row = 0; row <= 3; row++)
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