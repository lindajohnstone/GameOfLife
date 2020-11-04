using System;

namespace GameOfLife
{
    public class OvercrowdingRule : IRules
    {
        GridSetUp _grid;
        public OvercrowdingRule(GridSetUp grid)
        {
            _grid = grid;
        }

        public bool Calculate(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (count > 4) return true;
            return false;
        }
    }
}