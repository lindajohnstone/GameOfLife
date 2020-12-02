using System;

namespace tests.GameOfLife
{
    public class GridUnderpop
    {
        int[,] grid = new [,]{
            {1,1,1},
            {1,0,1},
            {1,1,0},
        };
        public int[,] Grid { get; private set; }
        public int HowManyLiveNeighbours(int row, int col)
        {
            var rowPlusOne = row + 1;
            var rowMinusOne = row - 1;
            var colPlusOne = col + 1;
            var colMinusOne = col - 1;
            if (row == Grid.GetUpperBound(0)) rowPlusOne = Grid.GetLowerBound(0);
            if (row == Grid.GetLowerBound(0)) rowMinusOne = Grid.GetUpperBound(0);
            if (col == Grid.GetUpperBound(1)) colPlusOne = Grid.GetLowerBound(1);
            if (col == Grid.GetLowerBound(1)) colMinusOne = Grid.GetUpperBound(1);

            var neighbours = new [] { 
                Grid[row, colMinusOne], 
                Grid[row, colPlusOne],
                Grid[rowMinusOne, col],
                Grid[rowPlusOne, col],
                Grid[rowMinusOne, colMinusOne],
                Grid[rowMinusOne, colPlusOne],
                Grid[rowPlusOne, colMinusOne],
                Grid[rowPlusOne, colMinusOne]
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