using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class CellTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        public void Should_Test_Cell_State(int value, bool expected)
        {
            // arrange
            var cell = new Cell();
            // act
            var result = cell.GetState(value);
            // assert
            Assert.Equal(expected,result);
        }
    }
}