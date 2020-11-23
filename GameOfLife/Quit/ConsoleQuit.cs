using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public class ConsoleQuit : IQuit
    {
        ConsoleInput _input;
        public string _userInput;
        public ConsoleQuit()
        {
            _input = new ConsoleInput();
        }
        public bool Quit()
        {
            return CheckUserInput();
        }
        public bool CheckUserInput()
        {
            if (!Console.KeyAvailable) return true;
            _userInput = Console.ReadKey(true).ToString();
            if(_userInput.Equals("Q")) return false;
            return true;
        }
    }
}