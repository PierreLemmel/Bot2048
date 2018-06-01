using System.Collections;
using System.Collections.Generic;

namespace Bot2048.Model
{
    public class GridColumnCollection : IEnumerable<GridColumn>
    {
        private readonly Grid grid;

        internal GridColumnCollection(Grid grid)
        {
            this.grid = grid;
        }

        public GridColumn this[int col]
        {
            get { return new GridColumn(grid, col); }
        }

        public IEnumerator<GridColumn> GetEnumerator()
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