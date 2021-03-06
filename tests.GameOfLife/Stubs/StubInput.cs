using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class StubInput : IInput
    {
        private string _readLine;
        private string _readKey;
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public bool ConsoleKeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKeyInfo ReadKey(bool value)
        {
            return Console.ReadKey();
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

        public void ConsoleCancelKeyPress()
        {
            Console.CancelKeyPress += HandleCancelKeyPress;
        }
        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
        }
    }
}