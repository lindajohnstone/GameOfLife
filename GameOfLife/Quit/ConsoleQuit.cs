using System;
using System.Collections;
using System.Threading;

namespace GameOfLife
{
    public class ConsoleQuit : IQuit
    {
         
        private string _userInput;
      /*   public void CheckUserInput()
        {
            _userInput = GetUserInput();
        } */
        public void Quit()
        {
            _userInput = "Q";
        }
        public bool CheckUserInput()
        {
            if(!Console.KeyAvailable) return false;
            var _userInput = Console.ReadKey(true);
            if (_userInput.ToString() == "Q") return true;
            return false;
        }
    }
}