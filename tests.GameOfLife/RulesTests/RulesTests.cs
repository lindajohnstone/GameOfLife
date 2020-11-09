using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class RulesTests
    {
        const int row = 1;
        const int col = 1;
        [Fact]
        public void Should_Test_Underpopulation_Rule()
        {
            // arrange
            var grid = new GridUnderpop();
            var rule = new Underpop(grid);
            var expected = true;
            // act
            var result = rule.ManageRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_Overcrowding_Rule()
        {
            // arrange
            var grid = new Universe(new StubOutput());
            var rule = new OvercrowdingRule(grid);
            grid.SetUpGrid(Constants.GridLength, Constants.GridWidth);
            var expected = true;
            // act
            var result = rule.ManageRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_SurvivalRule()
        {
            // arrange
            var grid = new GridSurvival();
            var rule = new Survival(grid);
            var expected = true;
            // act
            var result = rule.ManageRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_ReproductionRule()
        {
            // arrange
            var grid = new GridRepro();
            var rule = new Reproduction(grid);
            var expected = true;
            // act
            var result = rule.ManageRules(row, col);
            // assert
            Assert.Equal(expected, result);
        }
    }
}