using System;

namespace GameOfLife
{
    public class UnderpopulationRule : IRules
    {
        private GridSetUp _grid;
        public UnderpopulationRule(GridSetUp grid)
        {
            _grid = grid;
        }
        public bool Calculate(int cellX, int cellY)
        {
            var count = _grid.HowManyLiveNeighbours(cellX, cellY);
            if (count < 2) return true;
            return false;
        }
    }
}