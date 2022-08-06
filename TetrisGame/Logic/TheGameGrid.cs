using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class TheGameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        public TheGameGrid(int rows, int colums)
        {
            this.Rows = rows;
            this.Columns = colums;
            grid = new int[rows, colums];
        }
        public bool InsideGride(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }
        public bool IsEmpty(int r, int c)
        {
            return InsideGride(r, c) && grid[r, c] == 0;
        }
        public bool IsRowFull(int r)//check if the game row full
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0) { return false; } // if there is one empty place the row is not full
            }
            return true;
        }
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0) { return false; } //if there is one full space in the row so the row is not epmty
            }
            return true;
        }
        private void ClearRow(int rowToClear)//This method get a row number and clear it
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[rowToClear, c] = 0;
            }
        }
        private void MoveRowsDown(int r, int numberOfRowsThatRemove)//this method push the half-full rows down after we clear a full row
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numberOfRowsThatRemove, c] = grid[r, c];
                grid[r, c] = 0;// delet the space[row,clum] that we alrady push
            }
        }
        public int ClearAllFullRows()//checking all the rows, if row is full, delet her and push down the blocks
        {
            int cleanedRow = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleanedRow++;
                }
                else if (cleanedRow > 0)
                {
                    MoveRowsDown(r, cleanedRow);
                }
            }
            return cleanedRow;
        }
    }
}
