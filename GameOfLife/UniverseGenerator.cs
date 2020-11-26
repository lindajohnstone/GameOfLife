using System;
using System.Threading;

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
        public event GridPrintEventHandler PrintGrid;
        public UniverseGenerator(IOutput output, Universe grid, IInput input, GameController game)
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
           
        }
        
        public void RunGame()
        {
            _grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            _grid.Initialise();
            do
            {
                while(!_input.ConsoleKeyAvailable())
                {
                    _output.Clear();
                    PrintGrid?.Invoke(this, new GridPrintEventArgs(_output, _grid.Grid)); 
                    _game.LoopThroughEachCell();
                    Thread.Sleep(200);
                }
            }
            while (_input.ReadKey(true).Key != ConsoleKey.Q);  
        }
    }
}