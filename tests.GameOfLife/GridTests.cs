using System;
using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class GridTests
    {
        [Fact]
        public void Should_Test_SetUpGrid()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            var gridLength = 10;
            var gridWidth = 10;
            var expected = new int[10,10];
            // act
            grid.SetUpGrid(gridLength, gridWidth);
            // assert
            Assert.Equal(expected.Length, grid.Grid.Length);
        }
        [Fact]
        public void Should_Test_InitialiseGrid()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            var gridLength = 3;
            var gridWidth = 3;
            grid.SetUpGrid(gridLength, gridWidth);
            var total = gridLength * gridWidth;
            var cell = new Cell();
            cell.CellState = State.Alive;
            var expected = new [,]{
                {cell,cell,cell},
                {cell,cell,cell},
                {cell,cell,cell},
            };
            // act
            grid.Initialise();
            // assert
            Assert.Equal(expected, grid.Grid);
        }
        [Fact]
        public void Should_Test_PrintGrid()
        {
            // arrange
            var output = new StubOutput();
            var grid = new Universe(output);
            var expected = "* ";
            // act
            grid.SetUpGrid(1,1);
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
            grid.SetUpGrid(3, 3);
            var row = 1;
            var col = 1;
            var expected = 8;
            // act
            var result = grid.HowManyLiveNeighbours(row, col);
            // assert 
            Assert.Equal(expected, result);
        }
    }
}
