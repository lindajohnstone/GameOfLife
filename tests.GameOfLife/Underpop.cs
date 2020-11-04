using System;

namespace tests.GameOfLife
{
    internal class Underpop
    {
        private GridUnderpop _grid;

        public Underpop(GridUnderpop grid)
        {
            _grid = grid;
        }

        internal bool Calculate(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (count < 2) return true;
            return false;
        }

    }
}