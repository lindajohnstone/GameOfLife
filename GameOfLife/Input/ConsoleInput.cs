using System;

namespace GameOfLife
{
    public class ConsoleInput : IInput
    {
        public void ConsoleCancelKeyPress()
        {
            Console.CancelKeyPress += HandleCancelKeyPress;
        }

        public bool ConsoleKeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKeyInfo ReadKey(bool value)
        {
           return Console.ReadKey(value);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
        private static void HandleCancelKeyPress(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
        }
    }
}