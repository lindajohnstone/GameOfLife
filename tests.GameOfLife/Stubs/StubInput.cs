using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class StubInput : IInput
    {
        private string _readLine;
        private string _readKey;
        private string _userInput = "Q";

        public string ReadKey()
        {
            return Console.ReadKey().ToString();
        }

        internal bool ConsoleKeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public string ReadKey(bool value)
        {
            return Console.ReadKey().ToString();
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
        public StubInput WithReadKey(string _userInput)
        {
            _readKey = _userInput;
            return this;
        }
    }
}