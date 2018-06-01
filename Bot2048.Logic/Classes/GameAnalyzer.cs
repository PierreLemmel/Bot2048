using System;
using System.Linq;
using Bot2048.Model;

namespace Bot2048.Logic
{
    internal class GameAnalyzer : IGameAnalyzer
    {
        public bool CanMoveLeft(Grid grid)
        {
            return grid.Rows.Any(row => CanMoveLeft(row));
        }

        private bool CanMoveLeft(GridRow row)
        {
            // No cells -> No movements
            if (row.All(cell => cell.IsEmpty()))
                return false;
            // Cells + empty space (except last cell) -> Movement possible
            else if (row.Take(3).Any(cell => cell.IsEmpty()))
                return true;
            else
            {
                // Check for any consecutive cells
                for (int col = 0; col <= 2; col++)
                {
                    if (row[col] == row[col + 1]) return true;
                }
                return false;
            }
        }

        public bool CanMoveRight(Grid grid)
        {
            return grid.Rows.Any(row => CanMoveRight(row));
        }

        private bool CanMoveRight(GridRow row)
        {
            // No cells -> No movements
            if (row.All(cell => cell.IsEmpty()))
                return false;
            // Cells + empty space (except last cell) -> Movement possible
            else if (row.Skip(1).Any(cell => cell.IsEmpty()))
                return true;
            else
            {
                // Check for any consecutive cells
                for (int col = 0; col <= 2; col++)
                {
                    if (row[col] == row[col + 1]) return true;
                }
                return false;
            }
        }

        public bool CanMoveDown(Grid grid)
        {
            return grid.Columns.Any(col => CanMoveDown(col));
        }

        private bool CanMoveDown(GridColumn column)
        {
            // No cells -> No movements
            if (column.All(cell => cell.IsEmpty()))
                return false;
            // Cells + empty space (except last cell) -> Movement possible
            else if (column.Skip(1).Any(cell => cell.IsEmpty()))
                return true;
            else
            {
                // Check for any consecutive cells
                for (int row = 0; row <= 2; row++)
                {
                    if (column[row] == column[row + 1]) return true;
                }
                return false;
            }
        }

        public bool CanMoveUp(Grid grid)
        {
            return grid.Columns.Any(col => CanMoveUp(col));
        }

        private bool CanMoveUp(GridColumn column)
        {
            // No cells -> No movements
            if (column.All(cell => cell.IsEmpty()))
                return false;
            // Cells + empty space (except last cell) -> Movement possible
            else if (column.Take(3).Any(cell => cell.IsEmpty()))
                return true;
            else
            {
                // Check for any consecutive cells
                for (int row = 0; row <= 2; row++)
                {
                    if (column[row] == column[row + 1]) return true;
                }
                return false;
            }
        }
    }
}
