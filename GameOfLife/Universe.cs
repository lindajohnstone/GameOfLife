using System;

namespace GameOfLife
{
    public class Universe
    {
        public Cell[,] Grid { get; private set; } 
        public void SetUpGrid(int gridLength, int gridWidth)
        {
            Grid = (Cell[,])Array.CreateInstance(typeof(Cell), gridLength, gridWidth);
        }
        public void Initialise()
        {
            for (int row = 0; row <= Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= Grid.GetUpperBound(1); col++)
                {
                    Cell cell = new Cell();
                    cell.CellState = State.Alive;
                    Grid[row, col] = cell;
                }
            }
        }
    }
}