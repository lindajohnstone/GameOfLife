﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace GameOfLife
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            // Console.CancelKeyPress += HandleCancelKeyPress;
            var output = new ConsoleOutput();
            var grid = new Universe();
            var input = new ConsoleInput();
            var quitGame = new ConsoleQuit();
            var game = new GameController(output, grid, input, quitGame);
            game.RunGame();
        }

        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
        }
    }
}
