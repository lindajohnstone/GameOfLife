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

        public bool Calculate(int row, int col)
        {
            //var cell = Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            /* if (cell == 0)
            { */
                if (count == 2) return true;
                else if (count == 3) return true;
            //}
            return false;
        }
    }
}