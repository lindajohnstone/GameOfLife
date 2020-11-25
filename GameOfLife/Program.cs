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
            var input = new ConsoleInput();
            var game = new GameController(grid);
            input.ConsoleCancelKeyPress();
            var generator = new UniverseGenerator(output, grid,input, game);
            generator.PrintGrid += GridPrintEvent.HandlePrintGrid;
            generator.RunGame();
        }
    }
}
