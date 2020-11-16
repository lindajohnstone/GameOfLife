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
            var grid = new Universe();
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
            var grid = new Universe();
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
            var grid = new Universe();
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(output, grid, rules);
            var expected = "* ";
            // act
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            game.PrintGrid();
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
            var grid = new Universe();
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(new StubOutput(), grid, rules);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            // act
            var result = game.HowManyLiveNeighbours(row, col);
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
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(new StubOutput(), grid, rules);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            // assert
            Assert.Throws<IndexOutOfRangeException>(() => game.HowManyLiveNeighbours(row, col));
        }
        [Fact]
        public void Should_Test_SwitchCellState()
        {
            // arrange
            var grid = new Universe();
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(new StubOutput(), grid, rules);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            game.SwitchCellState(row,col);
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
            // assert
            Assert.Equal(expected, cell.CellState);
        }
        [Fact]
        public void Should_Test_SwitchCellState_After_PrintGrid()
        {
            // arrange
            var grid = new Universe();
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(new StubOutput(), grid, rules);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            game.SwitchCellState(1,1);
            game.PrintGrid();
            var expected = State.Dead;
            var cell = grid.Grid[row, col];
            // assert
            Assert.Equal(expected, cell.CellState);
        }
        [Fact]
        public void Should_Test_ManageRules_Changes_CellState()
        {
            // arrange
            var grid = new Universe();
            var rules = new IRules[] 
            {
                new OvercrowdingRule(grid),
                new ReproductionRule(grid),
                new SurvivalRule(grid),
                new UnderpopulationRule(grid)
            };
            var game = new GameController(new StubOutput(), grid, rules);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var row = 1;
            var col = 1;
            var expected = State.Dead;
            // act
            game.ManageRules(row, col);
            // assert
            Assert.Equal(expected, grid.Grid[row, col].CellState);
        }
    }
}
