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
        [Theory]
        [InlineData(1, 1, 8)]
        [InlineData(2, 1, 8)]
        [InlineData(0, 1, 8)]
        [InlineData(Constants.GridLength - 1, Constants.GridWidth - 1, 8)] 
        public void Should_Count_Cell_NeighbourStateAlive(int row, int col, int expected)
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            // act
            var result = grid.HowManyLiveNeighbours(row, col);
            // assert 
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(Constants.GridLength, Constants.GridWidth)]
        [InlineData(-1, -1)]
        public void Should_Test_NeighbourStateAlive_Throws_If_Invalid_Input(int row, int col)
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            // assert
            Assert.Throws<IndexOutOfRangeException>(() => grid.HowManyLiveNeighbours(row, col));
        }
        [Fact]
        public void Should_Test_SwitchCellState()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(row,col);
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
            // assert
            Assert.Equal(expected, cell.CellState);
        }
        [Fact]
        public void Should_Test_SwitchCellState_After_PrintGrid()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(1,1);
            grid.PrintGrid();
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
            // assert
            Assert.Equal(expected, cell.CellState);
        }
        [Fact]
        public void Should_Test_ManageRules_Changes_CellState()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var row = 1;
            var col = 1;
            var expected = State.Dead;
            // act
            grid.ManageRules(row, col);
            // assert
            Assert.Equal(expected, grid.Grid[row, col].CellState);
        }
    }
}
