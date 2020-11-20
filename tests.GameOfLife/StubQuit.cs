using System;
using GameOfLife;

namespace tests.GameOfLife
{
    public class StubQuit : IQuit
    {
        private string _userInput = "Q";
        public string CheckUserInput()
        {
            return _userInput;
        }

        public void Quit()
        {
            _userInput = "Q";
        }
    }
}