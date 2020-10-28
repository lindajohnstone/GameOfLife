using System;

namespace tests.GameOfLife
{
    public class Grid
    {
        public Grid()
        {
        }

        public bool IsValid(string gridLength)
        {
           if (!int.TryParse(gridLength, out var x)) return false;
            if (x < 10) return false;
            return true;
        }

        public int[,] SetUpGrid(int gridLength, int gridWidth)
        {
            Array grid = Array.CreateInstance(typeof(int), gridLength, gridWidth);
            return (int[,])grid;
        }
    }
}