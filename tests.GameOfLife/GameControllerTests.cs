using System;
using GameOfLife;
using Xunit;
using Moq;

namespace tests.GameOfLife
{
    public class GameControllerTests
    {
        const int row = 1;
        const int col = 1;
        [Fact]
        public void Should_Test_ManageRules_Changes_CellState()
        {
            // arrange
            var grid = new Universe();
            var game = new GameController(new StubOutput(), grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var row = 1;
            var col = 1;
            var expected = State.Dead;
            // act
            game.CheckRules(row, col);
            // assert
            Assert.Equal(expected, grid.Grid[row, col].CellState);
        }
        [Fact]
        public void Should_Test_SwitchCellState_After_PrintGrid()
        {
            // arrange
            var grid = new Universe();
            var game = new GameController(new StubOutput(), grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(1,1);
            game.PrintGrid();
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
            // assert
            Assert.Equal(expected, cell.CellState);
        } 
        [Fact]
        public void Should_Test_SwitchCellState()
        {
            // arrange
            var grid = new Universe();
            var game = new GameController(new StubOutput(), grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(row,col);
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
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
            var game = new GameController(new StubOutput(), grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            // assert
            Assert.Throws<IndexOutOfRangeException>(() => grid.HowManyLiveNeighbours(row, col));
        }
        [Fact]
        public void Should_Test_PrintGrid()
        {
            // arrange
            var output = new StubOutput();
            var grid = new Universe();
            var game = new GameController(output, grid);
            var expected = "* ";
            // act
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            game.PrintGrid();
            // assert
            Assert.Equal(expected, output.GetWriteLine());
        }
        [Fact]
        public void Should_Check_Each_Cell_In_Grid()
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
            var game = new GameController(new StubOutput(), grid);
            // act
            game.LoopThroughEachCell();
            // assert
            Assert.Equal(State.Alive, grid.Grid[row, col].CellState);
        }
        [Theory]
        [InlineData(ConsoleKey.Q, true)]
        [InlineData(ConsoleKey.X, false)]
        public void Should_Test_QuitGame_Using_UserInput(ConsoleKey consoleKey, bool expected)
        {
            // arrange
            var endGame = new QuitGame();
            // act
            var result = endGame.ReadKeyToQuit(consoleKey);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_CancelKeyPressControlC()
        {
            // arrange
            var endGame = new QuitGame();
            var consoleKey = ConsoleSpecialKey.ControlC;
            var expected = true;
            // act
            var result = endGame.CancelKeyPressControlC(consoleKey);            
            // assert
            Assert.Equal(expected, result);
        }
    }
}