using System;

namespace GameOfLife
{
    public class Universe
    {
        public Cell[,] Grid { get; private set; } 
        IOutput _output;
        public Universe(IOutput output)
        {
            _output = output;
        }
        public void SetUpGrid(int gridLength, int gridWidth)
        {
            Grid = (Cell[,])Array.CreateInstance(typeof(Cell), gridLength, gridWidth);
        }
        public void Initialise()
        {
            for (int row = 0; row <= Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= Grid.GetUpperBound(1); col++)
                {
                    Cell cell = new Cell();
                    cell.CellState = State.Alive;
                    Grid[row, col] = cell;
                }
            }
        }
        public void RunGame()
        {
            SetUpGrid(Constants.GridLength, Constants.GridWidth);
            Initialise();
            SwitchCellState(1, 1); // TODO: add to ManageRules later
            PrintGrid();
        }
        public void PrintGrid()
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    if (Grid[row, col].CellState == State.Alive)
                    {
                        _output.Write("* ");
                    }
                    else if (Grid[row, col].CellState == State.Dead)
                    {
                        _output.Write("  ");
                    }
                }
                _output.WriteLine(Environment.NewLine);
            }
        }
        public int HowManyLiveNeighbours(int row, int col)
        {
            // replace row / col + or - with variables
            // if row = Grid.GetUpperBound(0)
            // row - 1 = Grid.GetLowerBound(0)
            // if row = Grid.GetLowerBound(0)
            // row + 1 = Grid.GetUpperBound(0)
            // if col = Grid.GetUpperBound(1)
            // col - 1 = Grid.GetLowerBound(1)
            // if col = Grid.GetLowerBound(1)
            // col + 1 = Grid.GetUpperBound(1)
            var rowPlusOne = row + 1;
            var rowMinusOne = row - 1;
            var colPlusOne = col + 1;
            var colMinusOne = col -1;
            if (row == Grid.GetUpperBound(0)) rowPlusOne = Grid.GetLowerBound(0);
            if (row == Grid.GetLowerBound(0)) rowMinusOne = Grid.GetUpperBound(0);
            if (col == Grid.GetUpperBound(1)) colPlusOne = Grid.GetLowerBound(1);
            if (col == Grid.GetLowerBound(1)) colMinusOne = Grid.GetUpperBound(1);

            var neighbours = new [] { 
                Grid[row, colMinusOne], 
                Grid[row, colPlusOne],
                Grid[rowMinusOne, col],
                Grid[rowPlusOne, col],
                Grid[rowMinusOne, colMinusOne],
                Grid[rowMinusOne, colPlusOne],
                Grid[rowPlusOne, colMinusOne],
                Grid[rowPlusOne, colMinusOne]
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
            var cell = Grid[row, col];
            cell.CellState = cell.CellState == State.Alive ? State.Dead : State.Alive;
            Grid[row, col] = cell;
        }
    }
}