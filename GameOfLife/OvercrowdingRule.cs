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

        public bool Calculate(int cellX, int cellY)
        {
            var count = _grid.HowManyLiveNeighbours(cellX, cellY);
            if (count > 4) return true;
            return false;
        }
    }
}