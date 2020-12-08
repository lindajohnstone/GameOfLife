using System;

namespace GameOfLife
{
    public static class GridPrintEvent
    {
        const int padRight = 2;
        const string aliveCell = "💟";
        const string deadCell = "💀";
        public static void HandlePrintGrid(object sender, GridPrintEventArgs args)
        { 
            for (int row = 0; row < args.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < args.Grid.GetLength(1); col++)
                {
                    args.Output.Write("|");
                    if (args.Grid[row, col].CellState == State.Alive)
                    {
                        args.Output.Write(aliveCell);
                    }
                    else if (args.Grid[row, col].CellState == State.Dead)
                    {
                        args.Output.Write(deadCell);
                    }
                }
                args.Output.WriteLine("|");  
                args.Output.CreateBorderHorizontalEdge();
            }
        }
    }
    public class GridPrintEventArgs : EventArgs
    {
        public IOutput Output {get;}
        public Cell[,] Grid {get;}
        public GridPrintEventArgs(IOutput output, Cell[,] grid)
        {
            Output = output;
            Grid = grid;
        }
    }
}
