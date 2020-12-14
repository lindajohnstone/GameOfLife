using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class UniverseTests
    {
        [Fact]
        public void Should_Test_SetUpGrid()
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var gridLength = 3;
            var gridWidth = 3;
            var expected = new Cell[gridLength,gridWidth];
            // act
            grid.SetUpGrid(gridLength, gridWidth);
            // assert
            Assert.Equal(expected.Length, grid.Grid.Length);
        }
        [Fact]
        public void Should_Test_InitialiseGrid()
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
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
    }
}
