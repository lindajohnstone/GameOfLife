using System;
using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class UniverseTests
    {
        const int row = 1;
        const int col = 1;
        [Fact]
        public void Should_Test_SetUpGrid()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            var gridLength = 3;
            var gridWidth = 3;
            var expected = new Cell[gridLength,gridWidth];
            // act
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            // assert
            Assert.Equal(expected.Length, grid.Grid.Length);
        }
        [Fact]
        public void Should_Test_InitialiseGrid()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            var cell = new Cell();
            // act
            grid.Initialise();
            // assert
            foreach (Cell cell_ in grid.Grid)
            {
                Assert.Equal(State.Alive, cell.CellState);
            }
        }
        [Fact]
        public void Should_Test_PrintGrid()
        {
            // arrange
            var output = new StubOutput();
            var grid = new Universe(output);
            var expected = "* ";
            // act
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.PrintGrid();
            // assert
            Assert.Equal(expected, output.GetWriteLine());
        }
        [Fact]
        public void Should_Count_Cell_NeighbourStateAlive()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var expected = 8;
            // act
            var result = grid.HowManyLiveNeighbours(row, col);
            // assert 
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_HowManyNeighbours_Wrapping()
        {
            // arrange
            
            // act

            // assert

        }
        [Fact]
        public void Should_Test_SwitchCellState()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(1,1);
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
            // assert
            Assert.Equal(expected, cell.CellState);
        }
    }
}
