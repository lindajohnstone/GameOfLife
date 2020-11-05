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

        public bool ManageRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (count > 4) return true;
            return false;
        }
    }
}