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
            var rule = new UnderpopulationRule(new GridSetUp(new StubOutput()));
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
            var rule = new OvercrowdingRule(new GridSetUp(new StubOutput()));
            var expected = true;
            // act
            var result = rule.Calculate(1, 1);
            // assert
            Assert.Equal(expected, result);
        }
    }
}