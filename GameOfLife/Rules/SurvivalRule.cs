using System;
using GameOfLife;

namespace GameOfLife
{
    public class SurvivalRule : IRules
    {
        private Universe _grid;
        private IOutput _output;
        private GameController _game;
        IRules[] _rules;
        public SurvivalRule(Universe grid)
        {
            _grid = grid;
            _game = new GameController(_output, _grid, _rules);
        } 

        public bool ManageRules(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _game.HowManyLiveNeighbours(row, col);
            if (cell .CellState == State.Alive)
            {
                if (count == Constants.CountSurvivalMin || count == Constants.CountSurvivalMax) return true; // TODO: add constants to all rules - if used in > 1 page add Constants class
            }
            return false;
        }
    }
}