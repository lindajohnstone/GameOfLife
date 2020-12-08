using System;

namespace GameOfLife
{
    public class ConsoleOutput : IOutput
    {

        public void Clear()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        public void Write(string v)
        {
            Console.Write(v);
        }

        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }

        public void CreateBorderHorizontalEdge()
        {
            var line = '-';
            var beginLine = " ";
            var borderWidth = Constants.GridWidth * 3;
            Console.WriteLine(beginLine.PadRight(borderWidth, line));
        }
    }
}