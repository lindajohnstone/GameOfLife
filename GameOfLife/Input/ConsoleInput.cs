using System;

namespace GameOfLife
{
    public class ConsoleInput : IInput
    {
        public bool ConsoleCancelKeyPress()
        {
            return Console.TreatControlCAsInput;
        }

        public bool ConsoleKeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public string ReadKey(bool value)
        {
           return Console.ReadKey(value).ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}