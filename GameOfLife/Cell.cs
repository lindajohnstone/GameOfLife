using System;

namespace GameOfLife
{
    public class Cell
    { 
        GridSetUp grid = new GridSetUp(new ConsoleOutput());
        public Cell()
        {
            CellState = State.Alive;
        }
        public State CellState { get; set; }
        public void SwitchState(int row, int col)
        {
            var cell = grid.Grid[row, col];
            cell = cell == 0 ? 1 : 0;
        }
    }
}