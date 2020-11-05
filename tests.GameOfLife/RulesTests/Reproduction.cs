using GameOfLife;

namespace tests.GameOfLife
{
    public class Reproduction : IRules
    {
        GridRepro _grid;

        public Reproduction(GridRepro grid)
        {
            _grid = grid;
        }

        public bool ManageRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (_grid.Grid[row, col] == 1 && count == 3) return true;
            return false;
        }
    }
}