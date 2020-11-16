using System;
using GameOfLife;

namespace GameOfLife
{
    public class SurvivalRule : IRules
    {
        private Universe _grid;
        private IOutput _output;
        private GameController _game;
        public SurvivalRule(Universe grid)
        {
            _grid = grid;
        } 

        public bool CheckRules(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (cell .CellState == State.Alive)
            {
                if (count == Constants.CountSurvivalMin || count == Constants.CountSurvivalMax) return true; 
            }
            return false;
        }
    }
}