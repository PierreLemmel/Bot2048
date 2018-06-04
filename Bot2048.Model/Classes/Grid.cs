using System;

namespace Bot2048.Model
{
    public class Grid
    {
        private readonly CellValue[,] cells;

        public GridColumnCollection Columns { get; }
        public GridRowCollection Rows { get; }

        public Grid()
        {
            cells = new CellValue[4, 4];

            Columns = new GridColumnCollection(this);
            Rows = new GridRowCollection(this);
        }

        private Grid(Grid other)
        {
            CellValue[,] values = (CellValue[,])other.cells.Clone();
            cells = values;
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

        public Grid Clone()
        {
            return new Grid(this);
        }
    }
}