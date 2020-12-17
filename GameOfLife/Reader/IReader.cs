using System.Collections.Generic;

namespace GameOfLife
{
    public interface IReader
    {
        string[] ReadFile(string filePath);
        string FileExists(string filePath);
    }
}