using System;

namespace GameOfLife
{
    public class OvercrowdingRule : IRules
    {
        Universe _grid;
        public OvercrowdingRule(Universe grid)
        {
            _grid = grid;
        } 
        public bool Check(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (cell.CellState == State.Alive)
            {
                if (count > Constants.CountOvercrowding) return true;
            }
            return false;
        }
    }
}