using System;

namespace GameOfLife
{
    public class OvercrowdingRule : IRules
    {
        Cell _cell;
        public OvercrowdingRule(Cell cell)
        {
            _cell = cell;
        }

        public bool Calculate(int cellX, int cellY)
        {
            var count = _cell.HowManyLiveNeighbours(cellX, cellY);
            if (count > 4) return true;
            return false;
        }
    }
}