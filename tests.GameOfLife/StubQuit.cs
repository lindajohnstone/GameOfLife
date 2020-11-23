using GameOfLife;

namespace tests.GameOfLife
{
    internal class StubQuit : IQuit
    {
        private StubInput _input;
        private string _userInput;

        public StubQuit(StubInput input)
        {
            _input = input;
        }

        public bool CheckUserInput()
        {
            //if (!_input.ConsoleKeyAvailable()) return true;
            _userInput = _input.ReadKey(true).ToString();
            _userInput = "Q";
            if(_userInput.Equals("Q")) return false;
            return true;
        }

        public bool Quit()
        {
            return CheckUserInput();
        }
    }
}