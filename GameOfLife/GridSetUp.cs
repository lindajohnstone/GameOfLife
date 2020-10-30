using System;

namespace GameOfLife
{
    public class GridSetUp
    {
        public int[,] Grid { get; private set; } 
    
        public void SetUpGrid(int gridLength, int gridWidth)
        {
            Grid = (int[,])Array.CreateInstance(typeof(int), gridLength, gridWidth);
        }

        public void Initialise()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i,j] = 0;
                }
            }
        }
    }
}