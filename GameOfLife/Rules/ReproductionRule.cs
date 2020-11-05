namespace GameOfLife
{
    public class ReproductionRule : IRules
    {
        private GridSetUp _grid;

        public ReproductionRule(GridSetUp grid)
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