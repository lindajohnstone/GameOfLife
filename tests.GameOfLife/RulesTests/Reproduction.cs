using GameOfLife;

namespace tests.GameOfLife
{
    public class Reproduction : IRules
    {
        GridRepro _grid;
        const int stateDead = 1;

        public Reproduction(GridRepro grid)
        {
            _grid = grid;
        }

        public bool ManageRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (_grid.Grid[row, col] == stateDead && count == Constants.CountReproduction) return true;
            return false;
        }
    }
}