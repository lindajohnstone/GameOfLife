using System;

namespace GameOfLife
{
    public class GridSetUp
    {
        public int[,] Grid { get; private set; } 
        IOutput _output;
        public GridSetUp(IOutput output)
        {
            _output = output;
        }
        public void SetUpGrid(int gridLength, int gridWidth)
        {
            Grid = (int[,])Array.CreateInstance(typeof(int), gridLength, gridWidth);
            /* Grid = new int[,] {
                {0,1,0},
                {1,0,1},
                {0,1,0},
            }; */
        }
        public void Initialise()
        {
            for (int row = 0; row < Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col < Grid.GetUpperBound(1); col++)
                {
                    Grid[row,col] = 0;
                }
            }
        }
        public void RunGame()
        {
            SetUpGrid(3, 3);
            PrintGrid();
        }
        public void PrintGrid()
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    var cell = Grid[row,col];
                    if (cell == 0)
                    {
                        _output.Write("* ");
                    }
                    else if (cell == 1)
                    {
                        _output.Write(" ");
                    }
                }
                _output.WriteLine(Environment.NewLine);
            }
        }
    }
}