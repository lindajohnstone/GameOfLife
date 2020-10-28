using System;

namespace GameOfLife
{
    public class GridSetUp
    {
        public int[,] Grid { get; private set; } // TODO: rename property
        public bool IsValid(int gridLength)
        {
            if (Grid != null && gridLength < Grid.GetLength(0)) return false; // TODO: input as (x,y)
            return true;
        }

        public void SetUpGrid(int gridLength, int gridWidth)
        {
            Grid = (int[,])Array.CreateInstance(typeof(int), gridLength, gridWidth);
        }
    }
}