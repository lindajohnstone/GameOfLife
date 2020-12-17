using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class RulesTests
    {   
        [Fact]
        public void Should_Test_UnderpopulationRule_Returns_False()
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new UnderpopulationRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var col = 1;
            var row = 1;
            var expected = false;
            // act
            var result = rule.Check(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(2,1,false)]
        [InlineData(1,1,true)]
        public void Should_Test_UnderpopulationRule(int cellX, int cellY, bool expected)
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new UnderpopulationRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(0,0);
            grid.SwitchCellState(0,1);
            grid.SwitchCellState(0,2);
            grid.SwitchCellState(1,0);
            grid.SwitchCellState(1,2);
            grid.SwitchCellState(2,0);
            grid.SwitchCellState(2,1);
            // act
            var result = rule.Check(cellX,cellY);
            // assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Should_Test_OvercrowdingRule_Returns_True()
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new OvercrowdingRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var col = 1;
            var row = 1;
            var expected = true;
            // act
            var result = rule.Check(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_SurvivalRule_Returns_False()
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new SurvivalRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var col = 1;
            var row = 1;
            var expected = false;
            // act
            var result = rule.Check(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_OvercrowdingRule_Returns_False() 
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new OvercrowdingRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var col = 1;
            var row = 1;
            grid.SwitchCellState(0,2); // passes for constant == 4 if line commented out
            grid.SwitchCellState(1,2);
            grid.SwitchCellState(2,0);
            grid.SwitchCellState(2,1);
            grid.SwitchCellState(2,2);
            var expected = false;
            // act
            var result = rule.Check(row, col);
            //assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1,1, false)]
        [InlineData(2,1, true)]
        public void Should_Test_SurvivalRule(int cellX, int cellY, bool expected)
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new SurvivalRule(grid);
            var gridLength = 3;
            var gridWidth = 4;
            grid.SetUpGrid(gridLength, gridWidth);
            grid.Initialise();
            grid.SwitchCellState(0,0);
            grid.SwitchCellState(0,1);
            grid.SwitchCellState(0,2);
            grid.SwitchCellState(0,3);
            grid.SwitchCellState(1,2);
            grid.SwitchCellState(1,3);
            grid.SwitchCellState(2,1);
            grid.SwitchCellState(2,2);
            grid.SwitchCellState(2,3);
            // act
            var result = rule.Check(cellX, cellY);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1,1,true)]
        [InlineData(2,0,false)]
        public void Should_Test_ReproductionRule(int cellX, int cellY, bool expected)
        {
            // arrange
            var fileInput = new FileReader();
            var grid = new Universe(fileInput);
            var rule = new ReproductionRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(0,0);
            grid.SwitchCellState(0,1);
            grid.SwitchCellState(0,2);
            grid.SwitchCellState(1,0);
            grid.SwitchCellState(1,1);
            grid.SwitchCellState(1,2);
            // act
            var result = rule.Check(cellX,cellY);
            // assert
            Assert.Equal(expected, result);
        }
    }
}