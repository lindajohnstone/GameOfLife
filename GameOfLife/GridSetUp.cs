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
        }
        public void Initialise()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i,j] = 0;
                }
            }
        }
        public void RunGame()
        {
            SetUpGrid(3, 3);
            //grid.Initialise();
            PrintGrid();
        }
        public void PrintGrid()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    var cell = Grid[i,j];
                    if (cell == 0)
                    {
                        _output.Write("* "); // TODO: add IOutput for testing. Same for line 37 & 40
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