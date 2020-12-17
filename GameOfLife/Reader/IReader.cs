using System.Collections.Generic;

namespace GameOfLife
{
    public interface IReader
    {
        string[] ReadFile();
        string FileExists();
    }
}