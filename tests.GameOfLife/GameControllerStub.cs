using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLife;

namespace tests.GameOfLife
{
    public class GameControllerStub
    {
        int[,] grid = new [,]{
            {0,0,1},
            {1,1,1},
            {1,1,0},
        };
        private Queue<char> _queue;
        StubOutput _output;
        public GameControllerStub(Queue<char> queue, StubOutput output)
        {
            _queue = queue;   
            _output = output;
        }
        public void RunGame()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(250));
                PrintGrid();
                if (_queue.TryDequeue(out char _) && _queue.Equals('q')) break;
            }
        }
        public void PrintGrid()
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == (int)State.Alive)
                    {
                        _output.Write("* ");
                    }
                    else if (grid[row, col] == (int)State.Dead)
                    {
                        _output.Write(". ");
                    }
                }
                _output.WriteLine(Environment.NewLine);
            }
        }
    }
}