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
        [Theory]
        [InlineData(State.Dead, 0)] 
        [InlineData(State.Alive, 1)] 
        public void Should_Test_SwitchState(State state, int expected)
        {
            // arrange
            var cell = new Cell();
            var row = 1;
            var col = 1;
            // act
            cell.SwitchState(row, col);
            // assert
            //Assert.Equal(expected, result);
        }
    }
}