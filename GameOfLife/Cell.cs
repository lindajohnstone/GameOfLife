using System;

namespace GameOfLife
{
    public class Cell
    {
        IOutput _output;
        GridSetUp _grid = new GridSetUp();
        public Cell(int gridLength, int gridWidth)
        {
            _grid.SetUpGrid(gridLength, gridWidth);
        }
        public StateEnum State { get; set; }

        public int NeighbourStateAliveCount(int cellX, int cellY)
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

        public int SwitchState(int cellX, int cellY)
        {
            if (_grid.Grid[cellX, cellY] == 0) return 1;
            return 0;
        }
    }
}