using System;

namespace GameOfLife
{
    public interface IQuit
    {
        public void Quit();
        public bool CheckUserInput();
    }
}