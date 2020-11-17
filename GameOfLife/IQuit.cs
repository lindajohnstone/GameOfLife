using System;

namespace GameOfLife
{
    public interface IQuit
    {
        public bool CancelKeyPressControlC(ConsoleSpecialKey consoleKey);
        public bool ReadKeyToQuit(ConsoleKey consoleKey);
    }
}