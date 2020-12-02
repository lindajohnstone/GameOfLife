using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class Underpop : IRules
    {
        GridUnderpop _grid;
        const State stateAlive = State.Alive;
        public Underpop(GridUnderpop grid)
        {
            _grid = grid;
        }

        public bool CheckRules(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            var count = _grid.HowManyLiveNeighbours(row, col);
            if (cell == (int)stateAlive)
            {
                if (count < Constants.CountUnderpopulation) return true;
            } 
            return false; 
        }
    }
}