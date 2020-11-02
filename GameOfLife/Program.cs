using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = new ConsoleOutput();
            var grid = new GridSetUp(output);
            grid.RunGame();
        }
    }
}
