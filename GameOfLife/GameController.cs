using System;
using System.Linq;

namespace GameOfLife
{
    public class GameController
    {
        IOutput _output;
        Universe _grid = new Universe();
        IRules[] _rules;
        public GameController(IOutput output, Universe grid, IRules[] rules)
        {
            _output = output;
            _grid = grid;
            _rules = rules;
        }
        public void RunGame()
        {
            _grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            _grid.Initialise();
            SwitchCellState(1, 1); // TODO: add to ManageRules later
            PrintGrid();
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
        public int HowManyLiveNeighbours(int row, int col)
        {
            var rowPlusOne = row + 1;
            var rowMinusOne = row - 1;
            var colPlusOne = col + 1;
            var colMinusOne = col - 1;
            if (row == _grid.Grid.GetUpperBound(0)) rowPlusOne = _grid.Grid.GetLowerBound(0);
            if (row == _grid.Grid.GetLowerBound(0)) rowMinusOne = _grid.Grid.GetUpperBound(0);
            if (col == _grid.Grid.GetUpperBound(1)) colPlusOne = _grid.Grid.GetLowerBound(1);
            if (col == _grid.Grid.GetLowerBound(1)) colMinusOne = _grid.Grid.GetUpperBound(1);

            var neighbours = new [] { 
                _grid.Grid[row, colMinusOne], 
                _grid.Grid[row, colPlusOne],
                _grid.Grid[rowMinusOne, col],
                _grid.Grid[rowPlusOne, col],
                _grid.Grid[rowMinusOne, colMinusOne],
                _grid.Grid[rowMinusOne, colPlusOne],
                _grid.Grid[rowPlusOne, colMinusOne],
                _grid.Grid[rowPlusOne, colMinusOne]
            }; 
            var count = 0;
            foreach(Cell neighbour in neighbours)
            {
                if(neighbour.CellState == State.Alive) 
                {
                    count++;
                }
            } 
            return count;
        }
        public void SwitchCellState(int row, int col)
        {
            var cell = _grid.Grid[row, col];
            cell.CellState = cell.CellState == State.Alive ? State.Dead : State.Alive;
            _grid.Grid[row, col] = cell;
        }
        public void ManageRules(int row, int col)
        {
            // loop through all rules
            // if any true
            // switch the cell state
            if (_rules.Any(_ => _.ManageRules(row, col))) SwitchCellState(row, col);
        }
    }
}