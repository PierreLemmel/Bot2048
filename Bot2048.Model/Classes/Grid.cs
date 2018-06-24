using System;

namespace Bot2048.Model
{
    public class Grid
    {
        private readonly CellValue[,] cells;

        public GridColumnCollection Columns { get; }
        public GridRowCollection Rows { get; }

        public Grid() : this(new CellValue[4, 4]) { }

        public Grid(CellValue[,] cells)
        {
            if (cells is null) throw new ArgumentNullException(nameof(cells));
            if (cells.GetLength(0) != 4) throw new ArgumentException(nameof(cells));
            if (cells.GetLength(1) != 4) throw new ArgumentException(nameof(cells));

            this.cells = cells;

            Columns = new GridColumnCollection(this);
            Rows = new GridRowCollection(this);
        }

        public CellValue this[int col, int row]
        {
            get { return cells[col, row]; }
            set { cells[col, row] = value; }
        }

        public void Clear()
        {
            for(int i=0; i <3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    cells[i, j] = CellValue.Empty;
                }
            }
        }
    }
}