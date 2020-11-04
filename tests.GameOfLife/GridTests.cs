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
            var grid = new GridSetUp(new StubOutput());
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
            var grid = new GridSetUp(new StubOutput());
            var gridLength = 3;
            var gridWidth = 3;
            grid.SetUpGrid(gridLength, gridWidth);
            var total = gridLength * gridWidth;
            var expected = new [,]{
                {0,0,0},
                {0,0,0},
                {0,0,0},
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
            var grid = new GridSetUp(output);
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
            var grid = new GridSetUp(new StubOutput());
            grid.SetUpGrid(3, 3);
            var row = 1;
            var col = 1;
            var expected = 8;
            // act
            var result = grid.HowManyLiveNeighbours(row, col);
            // assert 
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(State.Dead, 0)] 
        [InlineData(State.Alive, 1)] 
        public void Should_Test_SwitchState(State state, int expected)
        {
            // arrange
            var grid = new GridSetUp(new StubOutput());
            grid.SetUpGrid(3, 3);
            var row = 1;
            var col = 1;
            // act
            grid.SwitchCellState(row, col);
            // assert
            Assert.Equal(expected, result);
        }
    }
}
