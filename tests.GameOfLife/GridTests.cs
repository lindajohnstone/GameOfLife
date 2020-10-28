using System;
using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class GridTests
    {
        [Theory]
        [InlineData(10, 12, true)]
        [InlineData(9, 4, false)]
        public void Should_Test_Grid_GetLength_At_Least_Ten(int gridLength, int input, bool expected)
        {
            // arrange
            var grid = new GridSetUp();
            // act
            grid.SetUpGrid(gridLength, gridLength);
            var result = grid.IsValid(input);
            // assert
            Assert.Equal(expected, result);
        }
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
    }
}
