using System.Linq;

namespace GameOfLife
{
    public class GameController
    {
        Universe _grid = new Universe();
        IRules[] _rules;
        Universe _nextGrid = new Universe();
        public GameController(Universe grid)
        {
            _grid = grid;
            _rules = new IRules[] 
            {
                new OvercrowdingRule(_grid),
                new ReproductionRule(_grid),
                new SurvivalRule(_grid),
                new UnderpopulationRule(_grid)
            };
        }
        
        public void CheckRules(int row, int col)
        {
            if (_rules.Any(_ => _.CheckRules(row, col))) _grid.SwitchCellState(row, col);
        }

        public Universe LoopThroughEachCell()
        {
            _nextGrid.SetUpGrid(Constants.GridLength, Constants.GridWidth);

            for (int row = 0; row <= _grid.Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= _grid.Grid.GetUpperBound(1); col++)
                {
                    CheckRules(row, col);
                    _nextGrid.Grid[row, col] = _grid.Grid[row, col];
                }
            }
            return _nextGrid;
        }
    }
}