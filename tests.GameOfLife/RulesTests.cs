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
            var rule = new UnderpopulationRule(new Cell(3, 3));
            var expected = false;
            // act
            var result = rule.Calculate(1, 1);
            // assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Should_Test_Overcrowding_Rule()
        {
            // arrange
            var rule = new OvercrowdingRule(new Cell(3, 3));
            var expected = true;
            // act
            var result = rule.Calculate(1, 1);
            // assert
            Assert.Equal(expected, result);
        }
    }
}