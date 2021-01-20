namespace GameOfLife
{
    public class ReproductionRule : IRules
    {
        Universe _grid;
        public ReproductionRule(Universe grid)
        {
            _grid = grid;
        }

        public bool Check(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (cell.CellState == State.Dead && count == Constants.CountReproduction) return true;
            return false;
        }
    }
}