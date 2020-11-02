using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new GridSetUp();
            grid.SetUpGrid(3, 3);
            grid.Initialise();
            grid.PrintGrid();
        }
    }
}
