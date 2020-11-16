namespace GameOfLife
{
    public class ReproductionRule : IRules
    {
        Universe _grid;
        GameController _game;
        IOutput _output;
        IRules[] _rules;
        public ReproductionRule(Universe grid)
        {
            _grid = grid;
            _game = new GameController(_output, _grid, _rules);
        }

        public bool ManageRules(int row, int col)
        {
            var count = _game.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (cell.CellState == State.Dead && count == Constants.CountReproduction) return true;
            return false;
        }
    }
}