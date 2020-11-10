using System;

namespace GameOfLife
{
    public class Cell
    { 
        public Cell()
        {
            CellState = State.Alive;
        }
        public State CellState { get; set; }
    }
}