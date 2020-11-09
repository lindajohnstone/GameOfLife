using System;

namespace GameOfLife
{
    public class Universe
    {
        private int row = 1;
        private int col = 1;
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
            for (int row = 0; row < Grid.GetUpperBound(0); row++)
            {
                for (int col = 0; col < Grid.GetUpperBound(1); col++)
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
            SwitchCellState(row, col);
            PrintGrid();
        }
        public void PrintGrid()
        {
            for (int row = 0; row < Grid.GetLength(0); row++)
            {
                for (int col = 0; col < Grid.GetLength(1); col++)
                {
                    Cell cell = new Cell();
                    Grid[row,col] = cell;
                    if (cell.CellState == State.Alive)
                    {
                        _output.Write("* ");
                    }
                    else if (cell.CellState == State.Dead)
                    {
                        _output.Write("  ");
                    }
                }
                _output.WriteLine(Environment.NewLine);
            }
        }
        public int HowManyLiveNeighbours(int row, int col)
        {
            var neighbours = new [] { 
                Grid[row, col - 1], 
                Grid[row, col + 1],
                Grid[row - 1, col],
                Grid[row + 1, col],
                Grid[row - 1, col - 1],
                Grid[row - 1, col + 1],
                Grid[row + 1, col - 1],
                Grid[row + 1, col + 1]
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