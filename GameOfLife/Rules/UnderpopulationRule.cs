using System;

namespace GameOfLife
{
    public class UnderpopulationRule : IRules
    {
        private Universe _grid;
        private IOutput _output;
        private GameController _game;
        private IRules[] _rules;
        public UnderpopulationRule(Universe grid)
        {
            _grid = grid;
            _game = new GameController(_output, _grid, _rules);
        }
        public bool ManageRules(int cellX, int cellY)
        {
            var count = _game.HowManyLiveNeighbours(cellX, cellY);
            var cell = _grid.Grid[cellX, cellY];
            if (cell.CellState == State.Alive)
            {
                if (count < Constants.CountUnderpopulation) return true;
            }
            return false;
        }
    }
}