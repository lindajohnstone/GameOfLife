using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class StubQuit : IQuit
    {
        public bool CancelKeyPressControlC(ConsoleSpecialKey consoleKey)
        {
            return Console.TreatControlCAsInput = true;
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }

        public bool ReadKeyToQuit(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.Q) return true;
            return false;
        }
    }
}