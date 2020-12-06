using System;

namespace GameOfLife
{
    public interface IInput
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey(bool value);
        bool ConsoleKeyAvailable();
    }
}