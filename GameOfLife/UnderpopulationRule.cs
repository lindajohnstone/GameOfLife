using System;

namespace GameOfLife
{
    public class UnderpopulationRule : IRules
    {
        private Cell _cell;
        public UnderpopulationRule(Cell cell)
        {
            _cell = cell;
        }
        public bool Calculate(int cellX, int cellY)
        {
            var count = _cell.HowManyLiveNeighbours(cellX, cellY);
            if (count < 2) return true;
            return false;
        }
    }
}