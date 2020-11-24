using System;
using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            //Console.CancelKeyPress 
            var output = new ConsoleOutput();
            var grid = new Universe();
            var input = new ConsoleInput();
            var game = new GameController(output, grid, input);
            input.ConsoleCancelKeyPress();
            game.RunGame();
        }
    }
}
