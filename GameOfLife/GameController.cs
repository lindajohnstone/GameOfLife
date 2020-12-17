using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    public class GameController
    {
        Universe _grid;
        IRules[] _rules;
        ILogger<GameController> _gameControllerLogger;
        IReader _fileInput;

        public GameController(Universe grid, 
            ILogger<GameController> gameControllerLogger, 
            IReader fileInput)
        {
            _grid = grid;
            _gameControllerLogger = gameControllerLogger;
            _fileInput = fileInput;
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
            if (_rules.Any(_ => _.Check(row, col))) _grid.SwitchCellState(row, col);
        }

        public Universe LoopThroughEachCell() // TODO: rename GetNextUniverse
        {
            Universe nextGrid = new Universe(_fileInput);
            nextGrid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            if (_grid == null) _gameControllerLogger.LogInformation("_grid is null");
            if (_grid.Grid == null) _gameControllerLogger.LogInformation("_grid.Grid is null"); // TODO: more than one instance of grid
            for (int row = 0; row <= _grid.Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= _grid.Grid.GetUpperBound(1); col++)
                {
                    CheckRules(row, col);
                    nextGrid.Grid[row, col] = _grid.Grid[row, col];
                }
            }
            _grid = nextGrid;
            var hashCode = _grid.GetHashCode();
            //_gameControllerLogger.LogInformation($"This is the hash code from LoopThroughEachCell: {hashCode}");
            return _grid;
        }
    }
}