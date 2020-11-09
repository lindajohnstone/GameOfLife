using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class Survival : IRules
    {
        private GridSurvival _grid;

        public Survival(GridSurvival grid)
        {
            _grid = grid;
        }
        const int stateAlive = 0;

        public bool ManageRules(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (cell == stateAlive)
            { 
                if (count == Constants.CountSurvivalMin || count == Constants.CountSurvivalMax) return true;
            }
            return false;
        }
    }
}