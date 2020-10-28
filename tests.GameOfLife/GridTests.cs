using System;
using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class GridTests
    {
        [Theory]
        [InlineData("10", true)]
        [InlineData("9", false)]
        [InlineData("a", false)]
        public void Should_Test_Grid_GetLength_At_Least_Ten(string gridLength, bool expected)
        {
            // arrange
            var grid = new Grid();
            // act
            var result = grid.IsValid(gridLength);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void testName()
        {
            // arrange
            var grid = new Grid();
            var gridLength = 10;
            var gridWidth = 10;
            var expected = new int[10,10];
            // act
            var result = grid.SetUpGrid(gridLength, gridWidth);
            // assert
            Assert.Equal(expected.Length, result.Length);
        }
    }
}
