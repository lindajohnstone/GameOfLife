using GameOfLife;

namespace tests.GameOfLife
{
    public class Reproduction : IRules
    {
        GridRepro _grid;
        const State stateDead = State.Dead;

        public Reproduction(GridRepro grid)
        {
            _grid = grid;
        }

        public bool CheckRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (_grid.Grid[row, col] == (int)stateDead && count == Constants.CountReproduction) return true;
            return false;
        }
    }
}