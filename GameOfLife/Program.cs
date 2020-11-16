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
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(output, grid, rules);
            game.RunGame();
        }
    }
}
