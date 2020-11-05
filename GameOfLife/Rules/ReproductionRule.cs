namespace GameOfLife
{
    public class ReproductionRule : IRules
    {
        private Universe _grid;

        public ReproductionRule(Universe grid)
        {
            _grid = grid;
        }

        public bool ManageRules(int row, int col)
        {
            var count = _grid.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (cell == 1 && count == 3) return true;
            return false;
        }
    }
}