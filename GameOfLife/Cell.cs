using System;

namespace GameOfLife
{
    public class Cell
    {
        GridSetUp _grid; 
        IOutput _output; // TODO: warning: never assigned to and will always have its default value null
        public Cell(int gridLength, int gridWidth)
        {
            _grid = new GridSetUp(_output);
            _grid.SetUpGrid(gridLength, gridWidth);
        }
        public State CellState { get; set; }

        public int HowManyLiveNeighbours(int cellX, int cellY)
        {
            var neighbours = new [] { 
                _grid.Grid[cellX, cellY - 1], 
                _grid.Grid[cellX, cellY + 1],
                _grid.Grid[cellX - 1, cellY],
                _grid.Grid[cellX + 1, cellY],
                _grid.Grid[cellX - 1, cellY - 1],
                _grid.Grid[cellX - 1, cellY + 1],
                _grid.Grid[cellX + 1, cellY - 1],
                _grid.Grid[cellX + 1, cellY + 1]
            }; 
            var count = 0;
            foreach(int neighbour in neighbours)
            {
                if(neighbour == 0) 
                {
                    count++;
                }
            } 
            return count;
        }

        public int SwitchState(State state, int cellX, int cellY)
        {
            var cell = _grid.Grid[cellX, cellY];
            if (cell == 0) 
            {
                return 1;
            }
            return 0;
        }
    }
}