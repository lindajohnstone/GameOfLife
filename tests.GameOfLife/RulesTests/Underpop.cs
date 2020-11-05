using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class Underpop : IRules
    {
        GridUnderpop _grid;

        public Underpop(GridUnderpop grid)
        {
            _grid = grid;
        }

        public bool ManageRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (count < 2) return true;
            return false;
        }
    }
}