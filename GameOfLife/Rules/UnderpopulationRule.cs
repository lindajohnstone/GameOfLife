using System;

namespace GameOfLife
{
    public class UnderpopulationRule : IRules
    {
        private Universe _grid;
        public UnderpopulationRule(Universe grid)
        {
            _grid = grid;
        }
        public bool ManageRules(int cellX, int cellY)
        {
            var count = _grid.HowManyLiveNeighbours(cellX, cellY);
            if (count < Constants.CountUnderpopulation) return true;
            return false;
        }
    }
}