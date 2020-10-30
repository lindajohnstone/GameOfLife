using System;

namespace GameOfLife
{
    public class Cell
    {
        GridSetUp _grid = new GridSetUp();
        public Cell(int gridLength, int gridWidth)
        {
            _grid.SetUpGrid(gridLength, gridWidth);
        }
        public StateEnum State { get; set; }

        public int NeighbourStateCount(int cellX, int cellY)
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
    }
}