using System;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace GameOfLife
{
    public delegate void GridPrintEventHandler(Object sender, GridPrintEventArgs e);
    public class UniverseGenerator
    {
        IOutput _output;
        IInput _input;
        Universe _grid = new Universe();
        IRules[] _rules;
        Universe _nextGrid = new Universe();
        GameController _game;
        private readonly ILogger<UniverseGenerator> _universeGeneratorLogger;

        public event GridPrintEventHandler PrintGrid;
        public UniverseGenerator(IOutput output, Universe grid, IInput input, GameController game, ILogger<UniverseGenerator> universeGeneratorLogger)
        {
            _output = output;
            _grid = grid;
            _input = input;
            _rules = new IRules[] 
            {
                new OvercrowdingRule(_grid),
                new ReproductionRule(_grid),
                new SurvivalRule(_grid),
                new UnderpopulationRule(_grid)
            };
            _game = game;
            _universeGeneratorLogger = universeGeneratorLogger;
        }
        public void RunGame()
        {
            _grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            _grid.Initialise();
            var grid = _grid;
            _universeGeneratorLogger.LogInformation("New universe grid created", grid);
            do
            {
                while(!_input.ConsoleKeyAvailable())
                {
                    //_output.Clear();
                    _output.WriteLine("Testing");
                    PrintGrid?.Invoke(this, new GridPrintEventArgs(_output, grid.Grid)); 
                    grid = _game.LoopThroughEachCell();
                    Thread.Sleep(200);
                    var hashCode = grid.GetHashCode();
                    _output.WriteLine($"This is the Grid's hashcode: {hashCode}");
                }
            }
            while (_input.ReadKey(true).Key != ConsoleKey.Q);  
        }
    }
}