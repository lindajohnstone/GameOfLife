using System;
using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var output = new ConsoleOutput();
            var grid = new Universe();
            var game = new GameController(output, grid);
            game.RunGame();
        }
    }
}
