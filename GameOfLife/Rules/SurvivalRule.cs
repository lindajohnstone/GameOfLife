using System;
using GameOfLife;

namespace GameOfLife
{
    public class SurvivalRule : IRules
    {
        private Universe _grid;
        public SurvivalRule(Universe grid)
        {
            _grid = grid;
        } 

        public bool Check(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (cell .CellState == State.Dead)
            {
                if (count == Constants.CountSurvivalMin || count == Constants.CountSurvivalMax) return true; 
            }
            return false;
        }
    }
}