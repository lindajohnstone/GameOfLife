using Xunit;
using GameOfLife;

namespace tests.GameOfLife
{
    public class CellTests
    {
        [Theory]
        [InlineData(State.Alive)]
        [InlineData(State.Dead)]
        public void Should_Test_Cell_State(State state) 
        {
            // arrange
            var cell = new Cell();
            // act
            cell.CellState = state;
            // assert
            Assert.Equal(cell.CellState, state);
        }
    }
}