using System;
using GameOfLife;

namespace GameOfLife
{
    public class SurvivalRule : IRules
    {
        private GridSetUp _grid;
        public SurvivalRule(GridSetUp grid)
        {
            _grid = grid;
        } 

        public bool ManageRules(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (cell == 0)
            {
                if (count == 2 || count == 3) return true;
            }
            return false;
        }
    }
}