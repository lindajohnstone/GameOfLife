using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class RulesTests
    {
        const int row = 1;
        const int col = 1;
        [Theory]
        [InlineData(1,0,false)]// TODO: All fail : System.NullReferenceException
        [InlineData(1,1,false)]
        [InlineData(2,1,false)]
        public void Should_Test_UnderpopulationRule_With_Stub(int cellX, int cellY, bool expected)
        {
            // arrange
            var grid = new GridUnderpop();
            var rule = new Underpop(grid);
            //var expected = true;
            // act
            var result = rule.CheckRules(cellX, cellY);
            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_Test_UnderpopulationRule_Returns_False()
        {
            // arrange
            var grid = new Universe();
            var rule = new UnderpopulationRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var expected = false;
            // act
            var result = rule.CheckRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(2,1,false)]
        [InlineData(1,1,true)]//TODO: fails
        public void Should_Test_UnderpopulationRule(int cellX, int cellY, bool expected)
        {
            // arrange
            var grid = new Universe();
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
            var result = rule.CheckRules(2,1);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_Overcrowding_Rule()
        {
            // arrange
            var grid = new Universe();
            var rule = new OvercrowdingRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var expected = true;
            // act
            var result = rule.CheckRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1,1,true)]
        [InlineData(2,2,false)]
        public void Should_Test_SurvivalRule_With_Stub(int cellX, int cellY, bool expected)
        {
            // arrange
            var grid = new GridSurvival();
            var rule = new Survival(grid);
            //var expected = true;
            // act
            var result = rule.CheckRules(cellX, cellY);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_SurvivalRule_Returns_False()
        {
            // arrange
            var grid = new Universe();
            var rule = new SurvivalRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            var expected = false;
            // act
            var result = rule.CheckRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1,1,true)]
        [InlineData(0,0,false)]
        public void Should_Test_ReproductionRule_With_Stub(int cellX, int cellY, bool expected)
        {
            // arrange
            var grid = new GridRepro();
            var rule = new Reproduction(grid);
            // act
            var result = rule.CheckRules(cellX, cellY);
            // assert
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1,1,true)]
        [InlineData(2,0,false)]
        public void Should_Test_ReproductionRule(int cellX, int cellY, bool expected)
        {
            // arrange
            var grid = new Universe();
            var rule = new ReproductionRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            grid.Initialise();
            grid.SwitchCellState(0,0);
            grid.SwitchCellState(0,1);
            grid.SwitchCellState(0,2);
            grid.SwitchCellState(1,0);
            grid.SwitchCellState(1,1);
            grid.SwitchCellState(1,2);
            //var expected = true;
            // act
            var result = rule.CheckRules(cellX,cellY);
            // assert
            Assert.Equal(expected, result);
        }
    }
}