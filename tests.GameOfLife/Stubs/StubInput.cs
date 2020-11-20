using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class StubInput : IInput
    {
        private string _readLine;

        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public char ReadKey(bool value)
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            return _readLine;
        }

        public StubInput WithReadLine(string value) 
        {
            _readLine = value;
            return this;
        }
    }
}