using System;

namespace GameOfLife
{
    public class Cell
    {
        public Cell()
        {
        }
        public int State { get; set; }

        public bool GetState(int cell)
        {
            if (cell == 0) return true;
            return false;
        }
    }
}