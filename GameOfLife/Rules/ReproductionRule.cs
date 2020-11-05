namespace GameOfLife
{
    public class ReproductionRule : IRules
    {
        private Universe _grid;
        const int liveNeighbours = 3;
        public ReproductionRule(Universe grid)
        {
            _grid = grid;
        }

        public bool ManageRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (cell.CellState == State.Dead && count == liveNeighbours) return true;
            return false;
        }
    }
}