namespace tests.GameOfLife
{
    public class GridSurvival
    {
        int[,] grid = new [,]{
            {1,1,1},
            {0,0,1},
            {0,1,0},
        };
        public int[,] Grid { get; private set; }

        public GridSurvival()
        {
            Grid = grid;
        }

        public int HowManyLiveNeighbours(int row, int col)
        {
            var neighbours = new [] { 
                grid[row, col - 1], 
                grid[row, col + 1],
                grid[row - 1, col],
                grid[row + 1, col],
                grid[row - 1, col - 1],
                grid[row - 1, col + 1],
                grid[row + 1, col - 1],
                grid[row + 1, col + 1]
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