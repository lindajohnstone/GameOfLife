using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class RulesTests
    {
        [Fact]
        public void Should_Test_Underpopulation_Rule()
        {
            // arrange
            var grid = new GridUnderpop();
            var rule = new Underpop(grid);
            var expected = true;
            // act
            var result = rule.Calculate(1,1);
            // assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Should_Test_Overcrowding_Rule()
        {
            // arrange
            var grid = new GridSetUp(new StubOutput());
            var rule = new OvercrowdingRule(grid);
            grid.SetUpGrid(3, 3);
            var expected = true;
            // act
            var result = rule.Calculate(1, 1);
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
            var result = rule.Calculate(1, 1);
            // assert
            Assert.Equal(expected, result);
        }
    }
}