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

        public bool ManageRules(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (cell .CellState == State.Alive)
            {
                if (count == Constants.CountSurvivalMin || count == Constants.CountSurvivalMax) return true; // TODO: add constants to all rules - if used in > 1 page add Constants class
            }
            return false;
        }
    }
}