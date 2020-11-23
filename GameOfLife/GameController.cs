using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class GameController
    {
        IOutput _output;
        IInput _input;
        Universe _grid = new Universe();
        IRules[] _rules;
        public GameController(IOutput output, Universe grid, IInput input)
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
        }
        public void RunGame()
        {
            _grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            _grid.Initialise();
            do
            {
                while(!_input.ConsoleKeyAvailable())
                {
                    PrintGrid();
                    LoopThroughEachCell();
                    Thread.Sleep(500);
                    _output.Clear();
                }
            }
            while (_input.ReadKey(true).Key != ConsoleKey.Q);  
        }

        public void PrintGrid()
        {
            for (int row = 0; row < _grid.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < _grid.Grid.GetLength(1); col++)
                {
                    if (_grid.Grid[row, col].CellState == State.Alive)
                    {
                        _output.Write("* ");
                    }
                    else if (_grid.Grid[row, col].CellState == State.Dead)
                    {
                        _output.Write(". ");
                    }
                }
                _output.WriteLine(Environment.NewLine);
            }
        }
        
        
        public void CheckRules(int row, int col)
        {
            if (_rules.Any(_ => _.CheckRules(row, col))) _grid.SwitchCellState(row, col);
        }

        public void LoopThroughEachCell()
        {
            for (int row = 0; row <= _grid.Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= _grid.Grid.GetUpperBound(1); col++)
                {
                    CheckRules(row, col);
                }
            }
        }
    }
}