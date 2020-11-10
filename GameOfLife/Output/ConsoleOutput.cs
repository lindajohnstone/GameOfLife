using System;

namespace GameOfLife
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string v)
        {
            Console.Write(v);
        }

        public void WriteLine(string v)
        {
            Console.WriteLine(v);
        }
    }
}