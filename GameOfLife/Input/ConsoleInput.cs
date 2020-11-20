using System;

namespace GameOfLife
{
    public class ConsoleInput : IInput
    {
        public bool KeyAvailable { get;}
        public char ReadKey(bool value)
        {
           return Console.ReadKey(value).KeyChar;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}