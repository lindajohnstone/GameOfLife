using System;
using System.Collections.Generic;
using GameOfLife;

namespace tests.GameOfLife
{
    public class StubOutput : IOutput
    {
        Queue<string> _queue;
        public StubOutput()
        {
            _queue = new Queue<string>();
        }
        public void WriteLine(string v)
        {
            _queue.Enqueue(v);
        }

        public void Write(string v)
        {
            _queue.Enqueue(v);
        }

        public string GetWriteLine() 
        {
            return _queue.Dequeue();
        }
        public string GetWrite() 
        {
            return _queue.Dequeue();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void CreateBorderHorizontalEdge()
        {
            var line = '-';
            var beginLine = " ";
            var borderWidth = 75;
            beginLine.PadRight(borderWidth, line);
        }
    }
}