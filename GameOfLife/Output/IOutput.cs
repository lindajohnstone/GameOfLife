using System;

namespace GameOfLife
{
    public interface IOutput
    {
        void WriteLine(string v);
        void Write(string v);
        void Clear();
        void CreateBorderHorizontalEdge();
    }
}