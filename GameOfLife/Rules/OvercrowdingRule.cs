using System;

namespace GameOfLife
{
    public class OvercrowdingRule : IRules
    {
        Universe _grid;
        GameController _game;
        IOutput _output;
        IRules[] _rules;
        public OvercrowdingRule(Universe grid)
        {
            _grid = grid;
            _game = new GameController(_output, _grid, _rules);
        } 
        public bool ManageRules(int row, int col)
        {
            var count = _game.HowManyLiveNeighbours(row, col);
            var cell = _grid.Grid[row, col];
            if (cell.CellState == State.Alive)
            {
                if (count > Constants.CountOvercrowding) return true;
            }
            return false;
        }
    }
}