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
            var grid = new GridSetUp();
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
            var grid = new GridSetUp();
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
        /* [Fact]
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
        } */
    }
}
