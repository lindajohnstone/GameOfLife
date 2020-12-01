using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    public class GameController
    {
        Universe _grid;
        IRules[] _rules;
        IOutput _output;

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
            Universe nextGrid = new Universe();
            nextGrid.SetUpGrid(Constants.GridLength, Constants.GridWidth);

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
            _output.WriteLine($"This is the hash code from LoopThroughEachCell: {hashCode}");
            return _grid;
        }
    }
}