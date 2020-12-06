using System;
using GameOfLife;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tests.GameOfLife
{
    public class GameControllerTests
    {
        const int row = 1;
        const int col = 1;
        [Theory]
        [InlineData(1,1,State.Dead)]
        [InlineData(2,2,State.Alive)]
        public void Should_Test_CheckRules_Changes_CellState(int cellX, int cellY, State expected)
        {
            // arrange
            var grid = new Universe();
            var game = new GameController(grid, new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var row = 1;
            var col = 1;
            // act
            game.CheckRules(cellX, cellY);
            // assert
            Assert.Equal(expected, grid.Grid[row, col].CellState);
        }
        [Theory]
        [InlineData(1,1, State.Dead)]
        [InlineData(1,2, State.Alive)]
        public void Should_Test_SwitchCellState(int cellX, int cellY, State expected)
        {
            // arrange
            var grid = new Universe();
            var game = new GameController(grid, new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(row,col);
            var cell = grid.Grid[cellX, cellY];
            // assert
            Assert.Equal(expected, cell.CellState);
        }
        [Theory]
        [InlineData(1, 1, 8)]
        [InlineData(2, 1, 8)]
        [InlineData(0, 1, 8)]
        [InlineData(Constants.GridLength - 1, Constants.GridWidth - 1, 8)] 
        public void Should_Count_Cell_NeighbourStateAlive(int row, int col, int expected)
        {
            // arrange
            var grid = new Universe();
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
            var grid = new Universe();
            var game = new GameController(grid, new StubOutput());
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            // assert
            Assert.Throws<IndexOutOfRangeException>(() => grid.HowManyLiveNeighbours(row, col));
        }
        [Theory]
        [InlineData(1,1,State.Dead)]
        [InlineData(0,0,State.Dead)]
        [InlineData(0,1,State.Dead)]
        [InlineData(0,2,State.Dead)]
        [InlineData(1,0,State.Dead)]
        [InlineData(1,2,State.Alive)] // fails
        [InlineData(2,0,State.Alive)] // fails
        [InlineData(2,1,State.Alive)] // fails
        [InlineData(2,2,State.Alive)] // fails
        public void Should_Check_LoopThroughEachCell(int cellX, int cellY, State expected) // TODO: change method name
        {
            // arrange
            var grid = new Universe();
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(grid, new StubOutput());
            // act
            game.LoopThroughEachCell();
            // assert
            Assert.Equal(expected, grid.Grid[cellX, cellY].CellState);
        }
    }
}