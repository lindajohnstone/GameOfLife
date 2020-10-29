using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class CellTests
    {
        [Theory]
        [InlineData("Alive", true)]
        [InlineData("Dead", false)]
        public void Should_Test_Cell_State(string state, bool expected) 
        {
            // arrange
            var cell = new Cell();
            // act
            cell.State = StateEnum.Alive;
            var cellToString = cell.State.ToString();
            var result = state.Equals(cellToString);
            // assert
            Assert.Equal(expected, result);
        }
    }
}