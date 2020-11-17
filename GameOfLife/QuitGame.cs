using System;

namespace GameOfLife
{
    public class QuitGame : IQuit
    {
        public bool CancelKeyPressControlC(ConsoleSpecialKey consoleKey)
        {
            return Console.TreatControlCAsInput = true;
        }

        public bool ReadKeyToQuit(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.Q) return true;
            return false;
        }
    }
}